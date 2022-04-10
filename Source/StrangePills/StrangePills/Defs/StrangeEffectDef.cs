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
        public void SuccessMessage(Pawn pawn)
        {
            Log.Message(successMessage);
            Messages.Message(successMessage.Translate(pawn.LabelShort),pawn, MessageTypeDefOf.PositiveEvent, true);
        }

        public string successMessage = "SP_NoMessage";
        public RandomGrade randomGrade = RandomGrade.Neutral;
        public float weight;
        public bool canEffectAnimals = false;
        public bool canEffectHumanoids = true;
        public List<RandomEffect> randomEffects;
    }
}
