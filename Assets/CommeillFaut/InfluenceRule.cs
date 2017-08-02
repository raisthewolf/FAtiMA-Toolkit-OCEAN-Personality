﻿using System;
using System.Collections.Generic;
using CommeillFaut.DTOs;
using Conditions;
using Conditions.DTOs;
using EmotionalAppraisal;
using KnowledgeBase;
using SerializationUtilities;
using WellFormedNames;


namespace CommeillFaut
{
    [Serializable]
    public class InfluenceRule
    {
        [NonSerialized]
        public readonly Guid GUID;

        public string RuleName { get; private set; }
        public string Target { get; private set; }
        public string Initiator { get; private set; }
        public int Value { get; private set; }
      public ConditionSet RuleConditions { get; private set; }


    protected InfluenceRule()
        {
            GUID = Guid.NewGuid();
        }

        public float Result(string init, string targ, KB m_Kb)
        {
           
            var toEvaluate = new ConditionSet(RuleConditions);
            var sub = new Substitution(Name.BuildName(Target), new ComplexValue(Name.BuildName(targ)));

            // m_Kb.AskPossibleProperties(Name.BuildName(targ), Name.BuildName("SELF"), new[] { new SubstitutionSet(sub) });

            //   Console.WriteLine( "uhm " + m_Kb.AskProperty(Name.BuildName("IsFriend(SELF,Peter)")).Certainty + sub.SubValue.Certainty);



            var eval = toEvaluate.Evaluate(m_Kb, Name.BuildName(init), new[] { new SubstitutionSet(sub) });

            // Console.WriteLine(evaluateResult + " InfluenceRule " + RuleConditions.ToDTO().ConditionSet[0] + " I am " + init + " sub " + Target + " for : " + targ + " certainty " + sub.SubValue.Certainty);
          if (eval)
            {
               
               
                var cond = toEvaluate.ToDTO().ConditionSet.GetValue(0).ToString().Split(new[] { '='});
                cond = cond[0].Split(new[] { ',' });
            //    Console.WriteLine(" going to get certainty of " + targ + " for this belief " + (cond[0] + "," + targ + ")"));
                var certainty = m_Kb.AskProperty(Name.BuildName(cond[0] + "," + targ + ")")).Certainty;

                return certainty;
            }
               
            else    return 0;
            
           
        }


        public InfluenceRule(InfluenceRuleDTO dto) : this()
		{
            SetData(dto);
        }

        public void SetData(InfluenceRuleDTO dto)
        {
            RuleName = dto.RuleName;
            Initiator = dto.Initiator;
            Target = dto.Target;
            Value = dto.Value;;
            RuleConditions = new ConditionSet(dto.RuleConditions);
        }

        public InfluenceRuleDTO ToDTO()
        {
            return new InfluenceRuleDTO() {Id = GUID, RuleName = RuleName, Initiator = Initiator, Target = Target, Value = Value, RuleConditions = RuleConditions.ToDTO()};
        }

       }


}