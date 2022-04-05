using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public class StrangeEffectDef : Def
    {
        public void SuccessMessage()
        {
            throw new NotImplementedException();
            //if (PawnUtility.ShouldSendNotificationAbout(user))
            //{
            //    Messages.Message("SkillNeurotrainerUsed".Translate(user.LabelShort, skill.LabelCap, level, level2, user.Named("USER")), user, MessageTypeDefOf.PositiveEvent, true);
            //}
        }

        public void FailMessage()
        {
            throw new NotImplementedException();
            //if (PawnUtility.ShouldSendNotificationAbout(user))
            //{
            //    Messages.Message("SkillNeurotrainerUsed".Translate(user.LabelShort, skill.LabelCap, level, level2, user.Named("USER")), user, MessageTypeDefOf.PositiveEvent, true);
            //}
        }

        public string successMessage = "No message set.";
        public string failMessage = "The strange pill had no effect.";
        public RandomGrade randomGrade = RandomGrade.Neutral;
        public float weight;
        public bool canEffectAnimals = false;
        public bool canEffectHumanoids = true;
        public List<RandomEffect> randomEffects;
    }
}
