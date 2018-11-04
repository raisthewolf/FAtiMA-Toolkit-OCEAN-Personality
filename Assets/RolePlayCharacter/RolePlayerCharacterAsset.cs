﻿using ActionLibrary;
using AutobiographicMemory;
using AutobiographicMemory.DTOs;
using CommeillFaut;
using EmotionalAppraisal;
using EmotionalAppraisal.DTOs;
using EmotionalAppraisal.OCCModel;
using EmotionalDecisionMaking;
using GAIPS.Rage;
using KnowledgeBase;
using MCTS;
using SerializationUtilities;
using SocialImportance;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using Utilities.Json;
using WellFormedNames;
using IQueryable = WellFormedNames.IQueryable;

namespace RolePlayCharacter
{
    [Serializable]
    public sealed class RolePlayCharacterAsset : LoadableAsset<RolePlayCharacterAsset>, ICustomSerialization
    {
        [NonSerialized]
        private Dictionary<Name, Identity> m_activeIdentities;

        private bool m_allowAuthoring;
        private string m_commeillFautAssetSource = null;
        private string m_emotionalAppraisalAssetSource = null;
        private string m_emotionalDecisionMakingAssetSource = null;
        private string m_socialImportanceAssetSource = null;

        [Serializable]
        private class LogEntry
        {
            public string Message { get; set; }
            public ulong Tick { get; set; }
        }

        private List<LogEntry> m_log;

        public RolePlayCharacterAsset()
        {
            m_log = new List<LogEntry>();
            m_activeIdentities = new Dictionary<Name, Identity>();
            m_kb = new KB(RPCConsts.DEFAULT_CHARACTER_NAME);
            m_am = new AM();
            m_emotionalState = new ConcreteEmotionalState();
            m_allowAuthoring = true;
            m_otherAgents = new Dictionary<Name, AgentEntry>();
            BindToRegistry(m_kb);
        }

        /// <summary>
        /// An identifier for the embodiment that is used by the character
        /// </summary>
        public string BodyName { get; set; }

        /// <summary>
        /// The name of the character
        /// </summary>
        public Name CharacterName
        {
            get { return m_kb.Perspective; }
            set { m_kb.SetPerspective(value); }
        }
        public string CommeillFautAssetSource
        {
            get { return ToAbsolutePath(m_commeillFautAssetSource); }
            set { m_commeillFautAssetSource = ToRelativePath(value); }
        }


        public bool IsPlayer { get; set; }

        /// <summary>
        /// The name of the action that the character is currently executing
        /// </summary>
        public Name CurrentActionName { get; set; }

        /// <summary>
        /// The target of the action that the character is currently executing
        /// </summary>
        public Name CurrentActionTarget { get; set; }

        public IDynamicPropertiesRegistry DynamicPropertiesRegistry => m_kb;

        /// <summary>
        /// The source being used for the Emotional Appraisal Asset
        /// </summary>
        public string EmotionalAppraisalAssetSource
        {
            get { return ToAbsolutePath(m_emotionalAppraisalAssetSource); }
            set { m_emotionalAppraisalAssetSource = ToRelativePath(value); }
        }

        /// <summary>
        /// The source being used for the Emotional Decision Making Asset
        /// </summary>
        public string EmotionalDecisionMakingSource
        {
            get { return ToAbsolutePath(m_emotionalDecisionMakingAssetSource); }
            set { m_emotionalDecisionMakingAssetSource = ToRelativePath(value); }
        }

        /// <summary>
        /// Gets all the recorded events experienced by the asset.
        /// </summary>
        public IEnumerable<EventDTO> EventRecords
        {
            get { return this.m_am.RecallAllEvents().Select(e => e.ToDTO()); }
        }

        /// <summary>
        /// The emotional mood of the agent, which can vary from -10 to 10
        /// </summary>
        public float Mood
        {
            get { return m_emotionalState.Mood; }
            set { m_emotionalState.Mood = value; }
        }

        public IQueryable Queryable
        {
            get { return m_kb; }
        }

        /// <summary>
        /// The source being used for the Social Importance Asset
        /// </summary>
        public string SocialImportanceAssetSource
        {
            get { return ToAbsolutePath(m_socialImportanceAssetSource); }
            set { m_socialImportanceAssetSource = ToRelativePath(value); }
        }

        /// <summary>
        /// The amount of update ticks this asset as experienced since its initialization
        /// </summary>
        public ulong Tick
        {
            get { return m_am.Tick; }
            set { m_am.Tick = value; }
        }

        /// <summary>
        /// An identifier for the voice that is used by the character
        /// </summary>
        public string VoiceName { get; set; }
        /// <summary>
        /// Creates a new <b>Active Emotion</b> and adds it to the asset's currently experiencing emotions set.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the given emotion is already being experienced by the asset.
        /// This can happend if in the given EmotionDTO the pair of parameters <b>Type</b> and <b>CauseEventId</b>
        /// are equal to an already existent ActiveEmotion in the asset.
        /// </exception>
        /// <param name="emotion">The DTO containing the emotion parameters to be used in the active emotion creation process</param>
        /// <returns>The DTO representing the actual emotion added to the active emotion set.</returns>
        public EmotionDTO AddActiveEmotion(EmotionDTO emotion)
        {
            return m_emotionalState.AddActiveEmotion(emotion, m_am);
        }

        /// <summary>
        /// Add an Event Record to the asset's autobiographical memory
        /// </summary>
        /// <param name="eventDTO">The dto containing the information regarding the event to add</param>
        /// <returns>The unique identifier associated to the event</returns>
        public uint AddEventRecord(EventDTO eventDTO)
        {
            if (!m_allowAuthoring)
                throw new Exception("This function is only available during authoring");

            return this.m_am.RecordEvent(eventDTO).Id;
        }

        public IEnumerable<IAction> Decide()
        {
            return this.Decide(Name.UNIVERSAL_SYMBOL);
        }

        public IEnumerable<IAction> Decide(Name layer)
        {
            if (m_emotionalDecisionMakingAsset == null) return new List<IAction>();

            if (CurrentActionName != null)
                return new IAction[]
                {
                    new ActionLibrary.Action(new Name[] {RPCConsts.COMMITED_ACTION_KEY, CurrentActionName},
                        CurrentActionTarget)
                };

            var possibleActions = m_emotionalDecisionMakingAsset.Decide(layer);

            var maxUtility = float.MinValue;
            foreach(var a in possibleActions)
            {
                if(a.Utility > maxUtility)
                {
                    maxUtility = a.Utility;
                }
            }

            var topActions = possibleActions.Where(a => a.Utility == maxUtility).Shuffle();
            var remainder = possibleActions.Where(a => a.Utility != maxUtility);
            return topActions.Concat(remainder);
        }

        /// <summary>
        /// Removes and forgets an event
        /// </summary>
        /// <param name="eventId">The id of the event to forget.</param>
        public void ForgetEvent(uint eventId)
        {
            this.m_am.ForgetEvent(eventId);
        }

        public IEnumerable<EmotionDTO> GetAllActiveEmotions()
        {
            return m_emotionalState.GetAllEmotions().Select(e => e.ToDto(m_am));
        }

        public IEnumerable<BeliefDTO> GetAllBeliefs()
        {
            return m_kb.GetAllBeliefs().Select(b => new BeliefDTO
            {
                Name = b.Name.ToString(),
                Perspective = b.Perspective.ToString(),
                Value = b.Value.ToString(),
                Certainty = b.Certainty
            });
        }

        /// <summary>
        /// Return the value associated to a belief.
        /// </summary>
        /// <param name="beliefName">The name of the belief to return</param>
        /// <returns>The string value of the belief, or null if no belief exists.</returns>
        public string GetBeliefValue(string beliefName, string perspective = Name.SELF_STRING)
        {
            var result = m_kb.AskProperty((Name)beliefName, (Name)perspective)?.Value.ToString();
            return result;
        }

        /// <summary>
        /// Return the value associated to a belief and its degree of certainty.
        /// </summary>
        /// <param name="beliefName">The name of the belief to return</param>
        /// <returns>The string value of the belief, or null if no belief exists.</returns>
        public ComplexValue GetBeliefValueAndCertainty(string beliefName, string perspective = Name.SELF_STRING)
        {
            return m_kb.AskProperty((Name)beliefName, (Name)perspective);
        }

        /// <summary>
        /// Returns all the associated information regarding an event
        /// </summary>
        /// <param name="eventId">The id of the event to retrieve</param>
        /// <returns>The dto containing the information of the retrieved event</returns>
        public EventDTO GetEventDetails(uint eventId)
        {
            return this.m_am.RecallEvent(eventId).ToDTO();
        }

        /// <summary>
        /// Retrieves the character's strongest emotion if any.
        /// </summary>
        public IActiveEmotion GetStrongestActiveEmotion()
        {
            IEnumerable<IActiveEmotion> currentActiveEmotions = m_emotionalState.GetAllEmotions();
            return currentActiveEmotions.MaxValue(a => a.Intensity);
        }

        /// <summary>
        /// Loads the associated assets from the defined sources and prevents further authoring of the asset
        /// </summary>
        public void LoadAssociatedAssets()
        {
            var charName = CharacterName.ToString();

            EmotionalAppraisalAsset ea = Loader(m_emotionalAppraisalAssetSource, () => new EmotionalAppraisalAsset());
     
            EmotionalDecisionMakingAsset edm = Loader(m_emotionalDecisionMakingAssetSource, () => new EmotionalDecisionMakingAsset());
            SocialImportanceAsset si = Loader(m_socialImportanceAssetSource, () => new SocialImportanceAsset());
            CommeillFautAsset cfa = Loader(m_commeillFautAssetSource, () => new CommeillFautAsset());

            m_emotionalAppraisalAsset = ea;
            m_emotionalDecisionMakingAsset = edm;
            m_socialImportanceAsset = si;
            m_commeillFautAsset = cfa;

            MCTSAsset mcts = new MCTSAsset();

            //Dynamic properties
            BindToRegistry(m_kb);

            edm.RegisterKnowledgeBase(m_kb);
            si.RegisterKnowledgeBase(m_kb);
            cfa.RegisterKnowledgeBase(m_kb);
            mcts.RegisterKnowledgeBase(m_kb);
            m_allowAuthoring = false;
        }


        public void LoadAssociatedAssetsFromString(string _ea, string _edm, string _si, string _cif)
        {
            var charName = CharacterName.ToString();

            EmotionalAppraisalAsset ea = new EmotionalAppraisalAsset();
            if(!_ea.IsEmpty())
             ea = EmotionalAppraisalAsset.LoadFromString(_ea);


            EmotionalDecisionMakingAsset edm = new EmotionalDecisionMakingAsset();
            if(!_edm.IsEmpty())
                edm = EmotionalDecisionMakingAsset.LoadFromString(_edm);

            SocialImportanceAsset si = new SocialImportanceAsset();
            if(!_si.IsEmpty())
            si = SocialImportanceAsset.LoadFromString(_si);

            CommeillFautAsset cif = new CommeillFautAsset();
            if(!_cif.IsEmpty())
            cif = CommeillFautAsset.LoadFromString(_cif);
           

            MCTSAsset mcts = new MCTSAsset();

            //Dynamic properties
            BindToRegistry(m_kb);
           
            edm.RegisterKnowledgeBase(m_kb);
            si.RegisterKnowledgeBase(m_kb);
            cif.RegisterKnowledgeBase(m_kb);
            mcts.RegisterKnowledgeBase(m_kb);
            m_allowAuthoring = false;

            m_emotionalAppraisalAsset = ea;
            m_emotionalDecisionMakingAsset = edm;
            m_socialImportanceAsset = si;
            m_commeillFautAsset = cif;
        }

        public void Perceive(Name evt)
        {
            this.Perceive(evt, Name.SELF_SYMBOL);
        }

        public void Perceive(Name evt, Name observer)
        {
            this.Perceive(new[] { evt }, observer );
        }

        public void Perceive(IEnumerable<Name> events)
        {
            this.Perceive(events, Name.SELF_SYMBOL);
        }

        public void Perceive(IEnumerable<Name> events, Name observer)
        {
            m_socialImportanceAsset.InvalidateCachedSI();

            var idx = 0;
            foreach (var e in events)
            {
                if (observer == Name.SELF_SYMBOL)
                {
                    if (RPCConsts.ACTION_START_EVENT_PROTOTYPE.Match(e))
                    {
                        var subject = e.GetNTerm(2);

                        if (subject == this.CharacterName)
                        {
                            CurrentActionName = e.GetNTerm(3);
                            CurrentActionTarget = e.GetNTerm(4);
                        }
                        //Add agent
                        this.AddKnownAgent(subject);
                    }
                    if (RPCConsts.ACTION_END_EVENT_PROTOTYPE.Match(e))
                    {
                        var actEndEvt = EventHelper.ActionEnd(this.CharacterName.ToString(), CurrentActionName?.ToString(),
                            CurrentActionTarget?.ToString());
                        if (actEndEvt.Match(e))
                        {
                            CurrentActionName = null;
                            CurrentActionTarget = null;
                        }
                        this.AddKnownAgent(e.GetNTerm(2));
                      
                    }
                }
                m_emotionalAppraisalAsset.AppraiseEvents(new[] { e }, observer, m_emotionalState, m_am, m_kb);
                idx++;
            }
        }

        public void RemoveEmotion(EmotionDTO emotion)
        {
            m_emotionalState.RemoveEmotion(emotion, m_am);
        }

        public void ResetEmotionalState()
        {
            this.m_emotionalState.Clear();
        }

        public void ActivateIdentity(Identity id)
        {
            var previous = GetActiveIdentities().Where(x => x.Category == id.Category).FirstOrDefault();
            if (previous != null) m_activeIdentities.Remove(previous.Name);
            m_activeIdentities[id.Name] = id;
        }

        public void DeactivateIdentity(Identity id)
        {
            m_activeIdentities.Remove(id.Name);
        }

        public IEnumerable<Identity> GetActiveIdentities()
        {
            return m_activeIdentities.Values;
        }

        public string SerializeToJSON()
        {
            var s = new JSONSerializer();
            return s.SerializeToJson(this).ToString(true);
        }

        /// <summary>
        /// Updates the character's internal state. Should be called once every game tick.
        /// </summary>
        public void Update()
        {
            Tick++;
            m_emotionalState.Decay(Tick);
        }

        /// <summary>
        /// Removes a belief from the asset's knowledge base.
        /// </summary>
        /// <param name="name">The name of the belief to remove.</param>
        /// <param name="perspective">The perspective of the belief to remove</param>
        public void RemoveBelief(string name, string perspective)
        {
            var p = (Name)perspective;
            m_kb.Tell(Name.BuildName(name), null, p);
        }

        public void UpdateBelief(string name, string value, float certainty = 1, string perspective = Name.SELF_STRING)
        {
            m_kb.Tell((Name)name, (Name)value, (Name)perspective, certainty);
        }
        
        /// <summary>
        /// Updates the associated data regarding a recorded event.
        /// </summary>
        /// <param name="eventDTO">The dto containing the information regarding the event to update. The Id field of the dto must match the id of the event we want to update.</param>
        public void UpdateEventRecord(EventDTO eventDTO)
        {
            if (!m_allowAuthoring)
                throw new Exception("This function is only available during authoring");

            this.m_am.UpdateEvent(eventDTO);
        }


        public override string ToString()
        {
            return this.CharacterName.ToString();
        }

        public string GetInternalStateString()
        {
            if (this.GetAllActiveEmotions().Any())
            {
                var emotion = GetBeliefValue("StrongestEmotion(SELF)");
                var intensity = this.GetAllActiveEmotions().Max(e => e.Intensity);
                return "M: " + this.Mood.ToString("F2") +
                       " | S. Em: " + emotion + "-" + intensity.ToString("F2");
            }
            else return "M: " + this.Mood.ToString("F2");
        }

        public string GetSIRelationsString()
        {
            var result = string.Empty;
            foreach (var target in this.m_otherAgents.Values)
            {
                var siProperty = "SI(" + target.Name + ")";
                var siToTarget = int.Parse(GetBeliefValue(siProperty));
                if (siToTarget > 1)
                {
                    result += siProperty + ":" + siToTarget + ", ";
                }
                
            }
            if (result != string.Empty) return result.Remove(result.Length - 2);
            else return result;
        }

        protected override string OnAssetLoaded()
        {
            return null;
        }

        protected override void OnAssetPathChanged(string oldpath)
        {
            if (!string.IsNullOrEmpty(m_emotionalAppraisalAssetSource))
                m_emotionalAppraisalAssetSource = ToRelativePath(AssetFilePath,
                    ToAbsolutePath(oldpath, m_emotionalAppraisalAssetSource));

            if (!string.IsNullOrEmpty(m_emotionalDecisionMakingAssetSource))
                m_emotionalDecisionMakingAssetSource = ToRelativePath(AssetFilePath,
                    ToAbsolutePath(oldpath, m_emotionalDecisionMakingAssetSource));

            if (!string.IsNullOrEmpty(m_socialImportanceAssetSource))
                m_socialImportanceAssetSource = ToRelativePath(AssetFilePath,
                    ToAbsolutePath(oldpath, m_socialImportanceAssetSource));

            if (!string.IsNullOrEmpty(m_commeillFautAssetSource))
                m_commeillFautAssetSource = ToRelativePath(AssetFilePath,
                    ToAbsolutePath(oldpath, m_commeillFautAssetSource));
        }


        private static IEnumerable<IAction> TakeBestActions(IEnumerable<IAction> enumerable)
        {
            float best = float.NegativeInfinity;
            foreach (var a in enumerable.OrderByDescending(a => a.Utility))
            {
                if (a.Utility < best)
                    break;

                yield return a;
                best = a.Utility;
            }
        }

        private void AddKnownAgent(Name agentName)
        {
            if (agentName != this.CharacterName)
            {
                if (!m_otherAgents.ContainsKey(agentName))
                    m_otherAgents.Add(agentName, new AgentEntry(agentName));
            }
        }

        public void BindToRegistry(IDynamicPropertiesRegistry registry)
        {
            registry.RegistDynamicProperty(RPCConsts.MOOD_PROPERTY_NAME, MoodPropertyCalculator);
            registry.RegistDynamicProperty(RPCConsts.STRONGEST_EMOTION_PROPERTY_NAME, StrongestEmotionCalculator);
            registry.RegistDynamicProperty(RPCConsts.STRONGEST_EMOTION_FOR_EVENT_PROPERTY_NAME, StrongestEmotionForEventCalculator);
            registry.RegistDynamicProperty(RPCConsts.STRONGEST_WELL_BEING_EMOTION_PROPERTY_NAME,
                StrongestWellBeingEmotionCalculator);
            registry.RegistDynamicProperty(RPCConsts.STRONGEST_ATTRIBUTION_PROPERTY_NAME,
                StrongestAttributionEmotionCalculator);
            registry.RegistDynamicProperty(RPCConsts.STRONGEST_COMPOUND_PROPERTY_NAME,
                StrongestCompoundEmotionCalculator);
            registry.RegistDynamicProperty(EMOTION_INTENSITY_TEMPLATE, EmotionIntensityPropertyCalculator);
            registry.RegistDynamicProperty(IS_AGENT_TEMPLATE, IsAgentPropertyCalculator);
            registry.RegistDynamicProperty(ROUND_TO_TENS_METHOD_TEMPLATE, RoundtoTensMethodCalculator);
            registry.RegistDynamicProperty(ROUND_METHOD_TEMPLATE, RoundMethodCalculator);
            registry.RegistDynamicProperty(RANDOM_METHOD_TEMPLATE, RandomCalculator);
            registry.RegistDynamicProperty(LOG_TEMPLATE, LogDynamicProperty);
            registry.RegistDynamicProperty(IS_SALIENT_TEMPLATE, IsSalientPropertyCalculator);
            m_am.BindToRegistry(registry);
        }

        private T Loader<T>(string path, Func<T> generateDefault) where T : LoadableAsset<T>
        {
            if (string.IsNullOrEmpty(path))
                return generateDefault();

            return LoadableAsset<T>.LoadFromFile(ToAbsolutePath(path));
        }

        #region RolePlayCharater Fields

        public KB m_kb;
        private AM m_am;
        public CommeillFautAsset m_commeillFautAsset;
        public EmotionalAppraisalAsset m_emotionalAppraisalAsset;
        public EmotionalDecisionMakingAsset m_emotionalDecisionMakingAsset;
        private ConcreteEmotionalState m_emotionalState;
        private Dictionary<Name, AgentEntry> m_otherAgents;
        public SocialImportanceAsset m_socialImportanceAsset;
        #endregion RolePlayCharater Fields
        #region Dynamic Properties

        private static readonly Name EMOTION_INTENSITY_TEMPLATE = (Name)"EmotionIntensity";

        private static readonly Name IS_AGENT_TEMPLATE = (Name)"IsAgent";

        private static readonly Name RANDOM_METHOD_TEMPLATE = (Name)"Random";

        private static readonly Name ROUND_METHOD_TEMPLATE = (Name)"RoundMethod";

        private static readonly Name ROUND_TO_TENS_METHOD_TEMPLATE = (Name)"RoundtoTensMethod";

        private static readonly Name IS_SALIENT_TEMPLATE = (Name)"IsSalient";

        private static readonly Name LOG_TEMPLATE = Name.BuildName("Log");

        private static readonly Name PERSONALITY_FACTOR_TEMPLATE = (Name)"PersonalityFactor";

        private IEnumerable<DynamicPropertyResult> PersonalityFactorCalculator(IQueryContext context, Name x, Name y) {
            if (context.Perspective != Name.SELF_SYMBOL)
                yield break;

            var emo = m_emotionalState.GetStrongestEmotion();
            if (emo == null)
                yield break;

            var emoValue = emo.EmotionType;

            if (x.IsVariable) {

                var sub = new Substitution(x, new ComplexValue(context.Queryable.Perspective));
                foreach (var c in context.Constraints) {
                    if (c.AddSubstitution(sub))
                        yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), c);
                }
            } else {
                foreach (var c in context.Constraints) {
                    yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), c);
                }
            }
        }

        private IEnumerable<DynamicPropertyResult> EmotionIntensityPropertyCalculator(IQueryContext context, Name x, Name y)
        {
           
            if (context.Perspective != Name.SELF_SYMBOL)
              yield break;

            Name entity = x;
            Name emotionName = y;

            if (entity.IsVariable)
            {

                foreach (var entit in context.AskPossibleProperties(entity))
                {
                    if (emotionName.IsVariable)
                    {
                        foreach (var emot in  GetAllActiveEmotions())
                        {
                                foreach (var c in context.Constraints)
                                {
                                    var sub = new Substitution(entity, entit.Item1);
                                    var sub2 = new Substitution(emotionName, new ComplexValue(Name.BuildName( emot.Type)));
                                    if(c.AddSubstitution(sub))
                                        if(c.AddSubstitution(sub2))
                                            yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(emot.Intensity)), c);
                                }
                            }
                        }
                    

                    else
                    {
                        
                        var gottem = GetAllActiveEmotions().Where(d => d.Type == emotionName.ToString());

                        if (!gottem.IsEmpty())
                        {
                            foreach (var c in context.Constraints)
                            {
                                var sub = new Substitution(entity, entit.Item1);
                                if(c.AddSubstitution(sub))
                                    yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(gottem.FirstOrDefault().Intensity)), c);
                            }
                        }
                    }

                }
            }
            else
            {
                if (emotionName.IsVariable)
                {
                    foreach (var emot in  GetAllActiveEmotions())
                    {
                        foreach (var c in context.Constraints)
                        {
                            var sub2 = new Substitution(emotionName, new ComplexValue(Name.BuildName( emot.Type)));
                                if(c.AddSubstitution(sub2))
                                    yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(emot.Intensity)), c);
                        }
                    }
                }

                else
                {
                    var gottem = GetAllActiveEmotions().Where(d => d.Type == emotionName.ToString());
                    if(!gottem.IsEmpty())
                        foreach (var c in context.Constraints)
                        {
                            yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(gottem.FirstOrDefault().Intensity)), c);
                        }
                }
            }
          
        }

        //This is a special property that is only used for debug purposes
        private IEnumerable<DynamicPropertyResult> LogDynamicProperty(IQueryContext context, Name varName)
        {
            foreach (var subSet in context.Constraints)
            {
                foreach (var sub in subSet.Where(s => s.Variable == varName))
                {
                    this.m_log.Add(new LogEntry
                    {
                        Message = "Sub Found: " + sub,
                        Tick = m_am.Tick
                    });
                }
                yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(true)), subSet);
            }
        }

        private IEnumerable<DynamicPropertyResult> GetEmotionsForEntity(IEmotionalState state,
            Name emotionName, WellFormedNames.IQueryable kb, Name perspective, IEnumerable<SubstitutionSet> constraints)
        {
            if (emotionName.IsVariable)
            {
                foreach (var emotion in state.GetAllEmotions())
                {
                    var sub = new Substitution(emotionName, new ComplexValue((Name)emotion.EmotionType));
                    foreach (var c in constraints)
                    {
                        if (c.Conflicts(sub))
                            continue;

                        var newConstraints = new SubstitutionSet(c);
                        newConstraints.AddSubstitution(sub);
                        yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(emotion.Intensity)), newConstraints);
                    }
                }
            }
            else
            {
                foreach (var resultPair in kb.AskPossibleProperties(emotionName, perspective, constraints))
                {
                    string emotionKey = resultPair.Item1.Value.ToString();
                    var emotion = state.GetEmotionsByType(emotionKey).OrderByDescending(e => e.Intensity).FirstOrDefault();
                    float value = emotion?.Intensity ?? 0;
                    foreach (var c in resultPair.Item2)
                        yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(value)), c);
                }
            }
        }

        private IEnumerable<DynamicPropertyResult> IsAgentPropertyCalculator(IQueryContext context, Name x)
        {
            if (context.Perspective != Name.SELF_SYMBOL)
                yield break;

            if (x.IsVariable)
            {
                var otherAgentsSubstitutions = m_otherAgents.Keys.Append(CharacterName).Select(n => new Substitution(x, new ComplexValue(n)));

                foreach (var s in otherAgentsSubstitutions)
                {
                    foreach (var set in context.Constraints)
                    {
                        if (set.Conflicts(s))
                            continue;

                        var r = new SubstitutionSet(set);
                        r.AddSubstitution(s);
                        yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(true)), r);
                    }
                }

                yield break;
            }

            if(m_otherAgents.ContainsKey(x) || x == context.Queryable.Perspective)
                foreach (var set in context.Constraints)
                {
                    yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(true)), set);
                }
            else
            {

                foreach (var set in context.Constraints)
                {
                    yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(false)), set);
                } 
            }
        }

        private IEnumerable<DynamicPropertyResult> MoodPropertyCalculator(IQueryContext context, Name x) 
            
            // Should only accept SELF, its rpc Name our a variable that should be subbed by its name
        {
            if (context.Perspective != Name.SELF_SYMBOL)
                yield break;


            if(x.IsVariable)
                foreach (var resultPair in context.AskPossibleProperties(x))
                {
                    var v = m_emotionalState.Mood;
                    foreach (var c in resultPair.Item2)
                    {
                        yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(v)), c);
                    }
                }
            else
            {
                if(x!= Name.SELF_SYMBOL && x != (Name)context.Queryable.Perspective)
                    yield break;
                
                var v = m_emotionalState.Mood;

                foreach (var c in context.Constraints)
                {
                    yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(v)), c);
                }
                
                if(context.Constraints.IsEmpty())
                    yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(v)), new SubstitutionSet());
            }
        }

        

        private IEnumerable<DynamicPropertyResult> IsSalientPropertyCalculator(IQueryContext context, Name identity)
        {
            foreach (var c in context.Constraints)
            {
                identity = identity.MakeGround(c);
                if (identity.IsGrounded)
                {
                    if (m_activeIdentities.ContainsKey(identity))
                    {
                        var id = m_activeIdentities[identity];
                        
                        yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(true), id.Salience), c);
                    }
                    else
                    {
                        yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(false)), c);
                    }
                }
            }
        }


        private IEnumerable<DynamicPropertyResult> RandomCalculator(IQueryContext context, Name min, Name max)
        {
            var minValue = Convert.ToInt32(min.ToString());
            var maxValue = Convert.ToInt32(max.ToString());

            Random rand = new Random();

            var toRet = rand.Next(minValue, maxValue);
            var subSet = new SubstitutionSet();
            
            yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(toRet)), subSet);
        }

        private IEnumerable<DynamicPropertyResult> RoundMethodCalculator(IQueryContext context, Name x, Name digits)
        {
            var y_value = Convert.ToInt32(digits.ToString());

            if (x.IsVariable)
            {
                foreach (var c in context.Constraints)
                {
                    foreach (var sub in c)
                    {
                        if (sub.Variable == x)
                        {
                            var toRet = Convert.ToDouble(sub.SubValue.ToString());
                            // Console.WriteLine("Round method calculation for: " + x.ToString() + " the value : " + toRet);
                            toRet = Math.Round(toRet, y_value);
                            //        Console.WriteLine("Round method calculation for: " + x.ToString() + " rounded value " + sub.Value.ToString()  + " digits: " + y_value + " result : " + toRet);

                            yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(toRet)), c);
                        }
                    }
                }
            }
        }

        private IEnumerable<DynamicPropertyResult> RoundtoTensMethodCalculator(IQueryContext context, Name x, Name digits)
        {
            var y_value = Convert.ToInt32(digits.ToString());
            var toTens = Math.Pow(10, y_value);

            if (x.IsVariable)
            {
                foreach (var c in context.Constraints)
                {
                    foreach (var sub in c)
                    {
                        if (sub.Variable == x)
                        {
                            var toRet = Convert.ToDouble(sub.SubValue.ToString());
                            // Console.WriteLine("Round method calculation for: " + x.ToString() + " the value : " + toRet);
                            toRet = toRet / toTens;
                            toRet = Math.Round(toRet, 0);
                            toRet = toRet * toTens;
                            //      Console.WriteLine("Round method calculation for: " + x.ToString() + " rounded value " + sub.Value.ToString()+ " result : " + toRet);

                            yield return new DynamicPropertyResult(new ComplexValue(Name.BuildName(toRet)), c);
                        }
                    }
                }
            }
        }
        private IEnumerable<DynamicPropertyResult> StrongestAttributionEmotionCalculator(IQueryContext context, Name x)
        {
            if (context.Perspective != Name.SELF_SYMBOL)
                yield break;

            var emotions = m_emotionalState.GetAllEmotions();

            if (!emotions.Any())
            {
                yield break;
            }

            var attributionEmotions = emotions.Where(
                em => em.EmotionType == OCCEmotionType.Shame.Name
                || em.EmotionType == OCCEmotionType.Pride.Name
                || em.EmotionType == OCCEmotionType.Reproach.Name
                || em.EmotionType == OCCEmotionType.Admiration.Name);

            if (!attributionEmotions.Any())
            {
                yield break;
            }

            var emo = attributionEmotions.MaxValue(em => em.Intensity);
            var emoValue = emo.EmotionType;

            if (x.IsVariable)
            {
                var sub = new Substitution(x, new ComplexValue(context.Queryable.Perspective));
                foreach (var c in context.Constraints)
                {
                    if (c.AddSubstitution(sub))
                        yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), c);
                }
            }
            else
            {
                foreach (var resultPair in context.Constraints)
                {
                        yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), resultPair);
                }
            }
        }

        private IEnumerable<DynamicPropertyResult> StrongestCompoundEmotionCalculator(IQueryContext context, Name x)
        {
            if (context.Perspective != Name.SELF_SYMBOL)
                yield break;

            var emotions = m_emotionalState.GetAllEmotions();

            if (!emotions.Any())
            {
                yield break;
            }

            var compoundEmotions = emotions.Where(
                em => em.EmotionType == OCCEmotionType.Gratification.Name
                || em.EmotionType == OCCEmotionType.Gratitude.Name
                || em.EmotionType == OCCEmotionType.Remorse.Name
                || em.EmotionType == OCCEmotionType.Anger.Name);

            if (!compoundEmotions.Any())
            {
                yield break;
            }

            var emo = compoundEmotions.MaxValue(em => em.Intensity);
            var emoValue = emo.EmotionType;

            if (x.IsVariable)
            {
                var sub = new Substitution(x, new ComplexValue(context.Queryable.Perspective));
                foreach (var c in context.Constraints)
                {
                    if (c.AddSubstitution(sub))
                        yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), c);
                }
            }
            else
            {
                foreach (var cont in context.Constraints)
                {
                        yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), cont);
                }
            }
        }

        private IEnumerable<DynamicPropertyResult> StrongestEmotionCalculator(IQueryContext context, Name x)
        {
            if (context.Perspective != Name.SELF_SYMBOL)
                yield break;

            var emo = m_emotionalState.GetStrongestEmotion();
            if (emo == null)
                yield break;

            var emoValue = emo.EmotionType;

            if (x.IsVariable)
            {

                var sub = new Substitution(x, new ComplexValue(context.Queryable.Perspective));
                foreach (var c in context.Constraints)
                {
                    if (c.AddSubstitution(sub))
                        yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), c);
                }
            }
            else
            {
                foreach (var c in context.Constraints)
                {
                    yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), c);
                }
            }
        }

        private IEnumerable<DynamicPropertyResult> StrongestEmotionForEventCalculator(IQueryContext context, Name x, Name cause)
        {
            if (context.Perspective != Name.SELF_SYMBOL)
                yield break;

           Dictionary<Name, IActiveEmotion> emoList = new Dictionary<Name, IActiveEmotion>();

            if (cause.IsVariable) // Event is a variable
            {
                 foreach (var ev in context.AskPossibleProperties(cause))
                    {
                        var emo = m_emotionalState.GetStrongestEmotion(cause, m_am);
                        if (emo != null)
                        {

                            var emoValue = emo.EmotionType;

                            var causeSub = new Substitution(cause, ev.Item1);


                            if (x.IsVariable)
                            {

                                var sub = new Substitution(x, new ComplexValue(context.Queryable.Perspective));
                                foreach (var c in context.Constraints)
                                {
                                    if (c.AddSubstitution(causeSub))

                                        if (c.AddSubstitution(sub))
                                            yield return new DynamicPropertyResult(new ComplexValue((Name) emoValue),
                                                c);
                                }
                            }
                            else
                            {
                                foreach (var resultPair in context.AskPossibleProperties(x))
                                {
                                    foreach (var c in resultPair.Item2)
                                        if (c.AddSubstitution(causeSub))
                                            yield return new DynamicPropertyResult(new ComplexValue((Name) emoValue),c);
                                }
                            }
                        }

                    }

                         foreach (var eve in this.EventRecords){ // If cause is a variable Im going through all events and emotions associated with them
                             
                             var sub = new Substitution(cause, new ComplexValue((Name)eve.Event));

                             var resultingEmotions = this.GetAllActiveEmotions().Where(y => y.CauseEventId == eve.Id);

                             var emoValue = resultingEmotions.MaxValue(e => e.Intensity);

                             foreach (var c in context.Constraints)
                             {
                                 if (c.AddSubstitution(sub))
                                     yield return new DynamicPropertyResult(
                                    new ComplexValue(Name.BuildName(emoValue.Intensity)), c);
                        }
                    }
                }
          
            else
            {
                var emo = m_emotionalState.GetStrongestEmotion(cause, m_am);
               
            if (emo == null)
            {
                yield break;
            }

                var emoValue = emo.EmotionType;

                if (x.IsVariable)
                {

                    var sub = new Substitution(x, new ComplexValue(context.Queryable.Perspective));
                    foreach (var c in context.Constraints)
                    {
                        if (c.AddSubstitution(sub))
                            yield return new DynamicPropertyResult(new ComplexValue((Name) emoValue), c);
                    }
                }
                else
                {
                    foreach (var resultPair in context.AskPossibleProperties(x))
                    {
                        foreach (var c in resultPair.Item2)
                            yield return new DynamicPropertyResult(new ComplexValue((Name) emoValue), c);
                    }
                }
            }
        }

        private IEnumerable<DynamicPropertyResult> StrongestWellBeingEmotionCalculator(IQueryContext context, Name x)
        {
            if (context.Perspective != Name.SELF_SYMBOL)
                yield break;

            var emotions = m_emotionalState.GetAllEmotions();

            if (!emotions.Any())
            {
                yield break;
            }

            var wellBeingEmotions = emotions.Where(
                em => em.EmotionType == OCCEmotionType.Joy.Name
                || em.EmotionType == OCCEmotionType.Distress.Name);

            if (!wellBeingEmotions.Any())
            {
                yield break;
            }

            var emo = wellBeingEmotions.MaxValue(em => em.Intensity);
            var emoValue = emo.EmotionType;

            if (x.IsVariable)
            {
                var sub = new Substitution(x, new ComplexValue(context.Queryable.Perspective));
                foreach (var c in context.Constraints)
                {
                    if (c.AddSubstitution(sub))
                        yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), c);
                }
            }
            else
            {
                foreach (var resultPair in context.Constraints)
                {
                  
                        yield return new DynamicPropertyResult(new ComplexValue((Name)emoValue), resultPair);
                }
            }
        }
        #endregion Dynamic Properties

        /// @cond DEV

        #region ICustomSerialization

        public void GetObjectData(ISerializationData dataHolder, ISerializationContext context)
        {
            dataHolder.SetValue("KnowledgeBase", m_kb);
            dataHolder.SetValue("BodyName", this.BodyName);
            dataHolder.SetValue("VoiceName", this.VoiceName);
            dataHolder.SetValue("EmotionalAppraisalAssetSource", this.m_emotionalAppraisalAssetSource);
            dataHolder.SetValue("EmotionalDecisionMakingSource", this.m_emotionalDecisionMakingAssetSource);
            dataHolder.SetValue("SocialImportanceAssetSource", this.m_socialImportanceAssetSource);
            dataHolder.SetValue("CommeillFautAssetSource", this.m_commeillFautAssetSource);
            dataHolder.SetValue("EmotionalState", m_emotionalState);
            dataHolder.SetValue("AutobiographicMemory", m_am);
            dataHolder.SetValue("OtherAgents", m_otherAgents);
            if (m_log.Any())
            {
                dataHolder.SetValue("UnifierLog", m_log);
            }
        }

        public void SetObjectData(ISerializationData dataHolder, ISerializationContext context)
        {
            m_allowAuthoring = true;
            m_log = new List<LogEntry>();
            m_activeIdentities = new Dictionary<Name, Identity>();
            m_kb = dataHolder.GetValue<KB>("KnowledgeBase");
            this.BodyName = dataHolder.GetValue<string>("BodyName");
            this.VoiceName = dataHolder.GetValue<string>("VoiceName");
            this.m_emotionalAppraisalAssetSource = dataHolder.GetValue<string>("EmotionalAppraisalAssetSource");
            this.m_emotionalDecisionMakingAssetSource = dataHolder.GetValue<string>("EmotionalDecisionMakingSource");
            this.m_socialImportanceAssetSource = dataHolder.GetValue<string>("SocialImportanceAssetSource");
            this.m_commeillFautAssetSource = dataHolder.GetValue<string>("CommeillFautAssetSource");
            m_emotionalState = dataHolder.GetValue<ConcreteEmotionalState>("EmotionalState");
            m_am = dataHolder.GetValue<AM>("AutobiographicMemory");
            m_otherAgents = dataHolder.GetValue<Dictionary<Name, AgentEntry>>("OtherAgents");
            if (m_otherAgents == null) { m_otherAgents = new Dictionary<Name, AgentEntry>(); }


            BindToRegistry(m_kb);
        }

        /// @endcond

        #endregion ICustomSerialization
    }
}