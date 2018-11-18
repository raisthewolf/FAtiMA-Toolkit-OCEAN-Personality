using AutobiographicMemory;
using Conditions.DTOs;
using EmotionalAppraisal.AppraisalRules;
using EmotionalAppraisal.DTOs;
using EmotionalAppraisal.OCCModel;
using GAIPS.Rage;
using KnowledgeBase;
using SerializationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using WellFormedNames;

namespace EmotionalAppraisal
{
    /// <summary>
    /// Main class of the Emotional Appraisal Asset.
    /// </summary>
    [Serializable]
    public sealed partial class EmotionalAppraisalAsset : LoadableAsset<EmotionalAppraisalAsset>, ICustomSerialization
    {
        [NonSerialized]
        private long _lastFrameAppraisal = 0;

        private ReactiveAppraisalDerivator m_appraisalDerivator;
        private EmotionDisposition m_defaultEmotionalDisposition;
        private Dictionary<string, EmotionDisposition> m_emotionDispositions;
        private Dictionary<string, Goal> m_goals;
        private Dictionary<string, double> m_personality;

        [NonSerialized]
        private OCCAffectDerivationComponent m_occAffectDerivator;

        /// <summary>
        /// Asset constructor.
        /// Creates a new empty Emotional Appraisal Asset.
        /// </summary>
        /// <param name="perspective">The initial perspective of the asset.</param>
        public EmotionalAppraisalAsset()
        {
            m_emotionDispositions = new Dictionary<string, EmotionDisposition>();
            m_goals = new Dictionary<string, Goal>();
            m_defaultEmotionalDisposition = new EmotionDisposition("*", 1, 1);
            m_occAffectDerivator = new OCCAffectDerivationComponent();
            m_appraisalDerivator = new ReactiveAppraisalDerivator();
            m_personality = new Dictionary<string, double>();

            m_personality.Add("Openness", 0.0);
            m_personality.Add("Conscientiousness", 0.0);
            m_personality.Add("Extraversion", 0.0);
            m_personality.Add("Agreeableness", 0.0);
            m_personality.Add("Neuroticism", 0.0);
        }

        public void setPersonalityFactor(string trait, double value) {
            string [] list = new string [5] {"Openness", "Conscientiousness", "Extraversion", "Agreeableness", "Neuroticism" };
            if (value >= -1.0 && value <= 1.0) {
                int check = 0;
                for (int i = 0; i < 5; i++) {
                    if (trait == list[i]) {
                        check = 1;
                    }
                }
                if (check == 1) {
                    m_personality[trait] = value;
                }
            }
        }

        public double getPersonalityFactor(string trait) {
            return m_personality[trait];
        }

        public void resetDispositionsToPersonality() {
            string[] traitList = new string[5] { "Openness", "Conscientiousness", "Extraversion", "Agreeableness", "Neuroticism" };
            string[] emotionList = new string[10] { "Admiration", "Anger", "Gratitude", "Distress", "Gratification", "Joy", "Pride", "Remorse", "Reproach", "Shame" };

            Dictionary<string, int> newValues = new Dictionary<string, int>();
            Dictionary<string, int> newValuesD = new Dictionary<string, int>();

            newValues["Anger"] = (int)(5 - m_personality["Neuroticism"]*3);
            newValuesD["Anger"] = (int)(5 + m_personality["Neuroticism"] * 3);

            newValues["Distress"] = (int)(5 - m_personality["Neuroticism"] * 3);
            newValuesD["Distress"] = (int)(5 + m_personality["Neuroticism"] * 3);

            newValues["Remorse"] = (int)(5 - (m_personality["Neuroticism"] + m_personality["Agreeableness"]) * 1.5);
            newValuesD["Remorse"] = (int)(5 + (m_personality["Neuroticism"] + m_personality["Agreeableness"]) * 1.5);

            newValues["Reproach"] = (int)(5 - m_personality["Neuroticism"] * 3);
            newValuesD["Reproach"] = (int)(5 + m_personality["Neuroticism"] * 3);

            newValues["Shame"] = (int)(5 - (m_personality["Neuroticism"] + m_personality["Agreeableness"]) * 1.5);
            newValuesD["Shame"] = (int)(5 + (m_personality["Neuroticism"] + m_personality["Agreeableness"]) * 1.5);

            newValues["Admiration"] = (int)(5 - m_personality["Agreeableness"] * 3);
            newValuesD["Admiration"] = (int)(5 + m_personality["Agreeableness"] * 3);

            newValues["Gratitude"] = (int)(5 - m_personality["Agreeableness"] * 3);
            newValuesD["Gratitude"] = (int)(5 + m_personality["Agreeableness"] * 3);

            newValues["Joy"] = (int)(5 - m_personality["Extraversion"] * 3);
            newValuesD["Joy"] = (int)(5 + m_personality["Extraversion"] * 3);

            newValues["Pride"] = (int)(5 - m_personality["Extraversion"] * 3);
            newValuesD["Pride"] = (int)(5 + m_personality["Extraversion"] * 3);

            newValues["Gratification"] = (int)(5 - m_personality["Extraversion"] * 3);
            newValuesD["Gratification"] = (int)(5 + m_personality["Extraversion"] * 3);

            for (int i = 0; i < 10; i++) {
                EmotionDisposition add = new EmotionDisposition(emotionList[i], newValuesD[emotionList[i]], newValues[emotionList[i]]);
                EmotionDispositionDTO dto = add.ToDto();
                AddEmotionDisposition(dto);
            }
        }

        public List<EmotionDispositionDTO> getPersonalityDispositions() {
            string[] traitList = new string[5] { "Openness", "Conscientiousness", "Extraversion", "Agreeableness", "Neuroticism" };
            string[] emotionList = new string[10] { "Admiration", "Anger", "Gratitude", "Distress", "Gratification", "Joy", "Pride", "Remorse", "Reproach", "Shame" };

            Dictionary<string, int> newValues = new Dictionary<string, int>();
            Dictionary<string, int> newValuesD = new Dictionary<string, int>();
            List<EmotionDispositionDTO> ret = new List<EmotionDispositionDTO>();

            newValues["Anger"] = (int)(5 - m_personality["Neuroticism"] * 3);
            newValuesD["Anger"] = (int)(5 + m_personality["Neuroticism"] * 3);

            newValues["Distress"] = (int)(5 - m_personality["Neuroticism"] * 3);
            newValuesD["Distress"] = (int)(5 + m_personality["Neuroticism"] * 3);

            newValues["Remorse"] = (int)(5 - (m_personality["Neuroticism"] + m_personality["Agreeableness"]) * 1.5);
            newValuesD["Remorse"] = (int)(5 + (m_personality["Neuroticism"] + m_personality["Agreeableness"]) * 1.5);

            newValues["Reproach"] = (int)(5 - m_personality["Neuroticism"] * 3);
            newValuesD["Reproach"] = (int)(5 + m_personality["Neuroticism"] * 3);

            newValues["Shame"] = (int)(5 - (m_personality["Neuroticism"] + m_personality["Agreeableness"]) * 1.5);
            newValuesD["Shame"] = (int)(5 + (m_personality["Neuroticism"] + m_personality["Agreeableness"]) * 1.5);

            newValues["Admiration"] = (int)(5 - m_personality["Agreeableness"] * 3);
            newValuesD["Admiration"] = (int)(5 + m_personality["Agreeableness"] * 3);

            newValues["Gratitude"] = (int)(5 - m_personality["Agreeableness"] * 3);
            newValuesD["Gratitude"] = (int)(5 + m_personality["Agreeableness"] * 3);

            newValues["Joy"] = (int)(5 - m_personality["Extraversion"] * 3);
            newValuesD["Joy"] = (int)(5 + m_personality["Extraversion"] * 3);

            newValues["Pride"] = (int)(5 - m_personality["Extraversion"] * 3);
            newValuesD["Pride"] = (int)(5 + m_personality["Extraversion"] * 3);

            newValues["Gratification"] = (int)(5 - m_personality["Extraversion"] * 3);
            newValuesD["Gratification"] = (int)(5 + m_personality["Extraversion"] * 3);

            for (int i = 0; i < 10; i++) {
                EmotionDisposition add = new EmotionDisposition(emotionList[i], newValuesD[emotionList[i]], newValues[emotionList[i]]);
                EmotionDispositionDTO dto = add.ToDto();
                ret.Add(dto);
            }
            return ret;
        }

        public EmotionDispositionDTO DefaultEmotionDisposition
        {
            get { return m_defaultEmotionalDisposition.ToDto(); }
            set { m_defaultEmotionalDisposition = new EmotionDisposition(value); }
        }

        /// <summary>
	    /// A short description of the asset's configuration
	    /// </summary>
	    public string Description { get; set; }

        /// <summary>
        /// The asset's currently defined Emotion Dispositions.
        /// </summary>
        public IEnumerable<EmotionDispositionDTO> EmotionDispositions
        {
            get { return m_emotionDispositions.Values.Select(disp => disp.ToDto()); }
        }

        /// <summary>
        /// The currently supported emotional type keys
        /// </summary>
        public static IEnumerable<string> EmotionTypes => OCCEmotionType.Types;

        /// <summary>
        /// Creates and adds an emotional disposition to the asset.
        /// </summary>
        /// <param name="emotionDispositionDto">The dto containing the parameters to create a new emotional disposition on the asset</param>
        public void AddEmotionDisposition(EmotionDispositionDTO emotionDispositionDto)
        {
            var disp = new EmotionDisposition(emotionDispositionDto);
            this.m_emotionDispositions.Add(disp.Emotion, disp);
        }

        /// <summary>
        /// Adds an emotional reaction to an event
        /// </summary>
        /// <param name="emotionalAppraisalRule">the AppraisalRule to add</param>
        public void AddOrUpdateAppraisalRule(AppraisalRuleDTO emotionalAppraisalRule)
        {
            m_appraisalDerivator.AddOrUpdateAppraisalRule(emotionalAppraisalRule);
        }

        public void AddOrUpdateGoal(GoalDTO goal)
        {
            m_goals[goal.Name] = new Goal(goal);
        }

        /// <summary>
        /// Appraises a set of event strings.
        ///
        /// Durring appraisal, the events will be recorded in the asset's autobiographical memory,
        /// and Property Change Events will update the asset's knowledge about the world, allowing
        /// the asset to use the new information derived from the events to appraise the correspondent
        /// emotions.
        /// </summary>
        /// <param name="eventNames">A set of string representation of the events to appraise</param>
        public void AppraiseEvents(IEnumerable<Name> eventNames, Name perspective, IEmotionalState emotionalState, AM am, KB kb)
        {
            var appraisalFrame = new InternalAppraisalFrame();
            appraisalFrame.Perspective = kb.Perspective;

            foreach (var n in eventNames)
            {
                var evt = am.RecordEvent(n, am.Tick);
                var propEvt = evt as IPropertyChangedEvent;
                if (propEvt != null)
                {
                    var fact = propEvt.Property;
                    var value = Name.BuildName("-");
                    if (propEvt.NewValue.IsPrimitive)
                    {
                        value = propEvt.NewValue;
                        if (value.ToString() == "-")
                        {
                            var remove = kb.GetAllBeliefs().Where(x => x.Name == fact);
                            kb.removeBelief(fact);
                        }
                        else
                        {
                            kb.Tell(fact, value, perspective);
                        }
                    }
                    else // new value is not grounded
                    {
                        var values =
                            kb.AskPossibleProperties(propEvt.NewValue, perspective, new List<SubstitutionSet>());
                        if (values.Count() == 1)
                        {
                            kb.Tell(fact, values.FirstOrDefault().Item1.Value, perspective);
                        }
                        else throw new Exception("Multiple possible values for " + propEvt.NewValue);
                    }
                }

                appraisalFrame.Reset(evt);
                var componentFrame = appraisalFrame.RequestComponentFrame(m_appraisalDerivator, m_appraisalDerivator.AppraisalWeight);
                m_appraisalDerivator.Appraisal(kb, evt, componentFrame);
                UpdateEmotions(appraisalFrame, emotionalState, am);
            }
        }

        public void AppraiseEvents(IEnumerable<Name> eventNames, IEmotionalState emotionalState, AM am, KB kb)
        {
            AppraiseEvents(eventNames, Name.SELF_SYMBOL, emotionalState, am, kb);
        }

        /// <summary>
        /// Returns the condition set used for evaluating a particular appraisal rule set.
        /// </summary>
        /// <param name="ruleId">The unique identifier of the appraisal rule.</param>
        /// <returns>The dto of the condition set associated to the requested appraisal rule.</returns>
        /// <exception cref="ArgumentException">Thrown if the requested appraisal rule could not be found.</exception>
        public ConditionSetDTO GetAllAppraisalRuleConditions(Guid ruleId)
        {
            var rule = m_appraisalDerivator.GetAppraisalRule(ruleId);
            if (rule == null)
                throw new ArgumentException($"Could not found requested appraisal rule for the id \"{ruleId}\"", nameof(ruleId));

            return rule.Conditions.ToDTO();
        }

        /// <summary>
        /// Returns all the appraisal rules
        /// </summary>
        /// <returns>The set of dtos containing the information for all the appraisal rules</returns>
        public IEnumerable<AppraisalRuleDTO> GetAllAppraisalRules()
        {
            return this.m_appraisalDerivator.GetAppraisalRules().Select(r => new AppraisalRuleDTO
            {
                Id = r.Id,
                EventMatchingTemplate = r.EventName,
                Desirability = r.Desirability,
                Praiseworthiness = r.Praiseworthiness,
                Conditions = r.Conditions.ToDTO()
            });
        }

        public IEnumerable<GoalDTO> GetAllGoals()
        {
            return this.m_goals.Values.Select(g => new GoalDTO {
                Name = g.Name.ToString(),
                Likelihood = g.Likelihood,
                Significance = g.Significance });
        }

        /// <summary>
        /// Returns the emotional dispotion associated to a given emotion type.
        /// </summary>
        /// <param name="emotionType">The emotion type key of the emotional disposition to retrieve</param>
        /// <returns>The dto containing the retrieved emotional disposition information</returns>
        public EmotionDispositionDTO GetEmotionDisposition(String emotionName)
        {
            EmotionDisposition disp;
            if (this.m_emotionDispositions.TryGetValue(emotionName, out disp))
                return disp.ToDto();

            return m_defaultEmotionalDisposition.ToDto();
        }

        public void GetObjectData(ISerializationData dataHolder, ISerializationContext context)
        {
            dataHolder.SetValue("Description", Description);
            dataHolder.SetValue("AppraisalRules", m_appraisalDerivator);
            dataHolder.SetValue("EmotionDispositions", m_emotionDispositions.Values.Prepend(m_defaultEmotionalDisposition).ToArray());
            dataHolder.SetValue("Goals", m_goals.Values.ToArray());
        }

        /// <summary>
        /// Removes appraisal rules from the asset.
        /// </summary>
        /// <param name="appraisalRules">A dto set of the appraisal rules to remove</param>
        public void RemoveAppraisalRules(IEnumerable<AppraisalRuleDTO> appraisalRules)
        {
            foreach (var appraisalRuleDto in appraisalRules)
            {
                m_appraisalDerivator.RemoveAppraisalRule(new AppraisalRule(appraisalRuleDto));
            }
        }

        /// <summary>
        /// Removes an emotional disposition from the asset.
        /// </summary>
        /// <param name="emotionType">The emotion type key of the emotional disposition to remove</param>
        public void RemoveEmotionDisposition(string emotionType)
        {
            this.m_emotionDispositions.Remove(emotionType);
        }

        public void RemoveGoals(IEnumerable<GoalDTO> goals)
        {
            foreach (var goal in goals)
            {
                this.m_goals.Remove(goal.Name);
            }
        }
        /// @cond DEV
        public void SetObjectData(ISerializationData dataHolder, ISerializationContext context)
        {
            Description = dataHolder.GetValue<string>("Description");

            m_appraisalDerivator = dataHolder.GetValue<ReactiveAppraisalDerivator>("AppraisalRules");
            m_occAffectDerivator = new OCCAffectDerivationComponent();

            if (m_emotionDispositions == null)
                m_emotionDispositions = new Dictionary<string, EmotionDisposition>();
            else
                m_emotionDispositions.Clear();

            var dispositions = dataHolder.GetValue<EmotionDisposition[]>("EmotionDispositions");
            EmotionDisposition defaultDisposition = null;
            foreach (var disposition in dispositions)
            {
                if (string.Equals(disposition.Emotion, "*", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (defaultDisposition == null)
                        defaultDisposition = disposition;
                }
                else
                    m_emotionDispositions.Add(disposition.Emotion, disposition);
            }
            if (defaultDisposition == null)
                defaultDisposition = new EmotionDisposition("*", 1, 1);
            m_defaultEmotionalDisposition = defaultDisposition;


            m_goals = new Dictionary<string, Goal>();
            var goals = dataHolder.GetValue<Goal[]>("Goals");
            foreach (var g in goals)
            {
                m_goals.Add(g.Name.ToString(), g);
            }
        }

        protected override string OnAssetLoaded()
        {
            return null;
        }

        private void UpdateEmotions(IAppraisalFrame frame, IEmotionalState emotionalState, AM am)
        {
            if (_lastFrameAppraisal > frame.LastChange)
            {
                return;
            }

            var emotions = m_occAffectDerivator.AffectDerivation(this, frame);
            foreach (var emotion in emotions)
            {
                var activeEmotion = emotionalState.AddEmotion(emotion, am, GetEmotionDisposition(emotion.EmotionType), am.Tick);
                if (activeEmotion == null)
                    continue;
            }

            _lastFrameAppraisal = frame.LastChange;
        }

        /// @endcond
    }
}