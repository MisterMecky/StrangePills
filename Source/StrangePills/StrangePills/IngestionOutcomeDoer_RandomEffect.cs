using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;


namespace StrangePills
{
    public class IngestionOutcomeDoer_RandomEffect : IngestionOutcomeDoer
    {
        //protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        //{
        //    List<StrangeEffectDef> list = DefDatabase<StrangeEffectDef>.AllDefs.ToList();
        //    StrangeEffectDef strangeEffect;
        //    list.DoRandomEffect<StrangeEffectDef>(out strangeEffect);
        //    if (strangeEffect.randomEffects != null)
        //    {
        //        //Log.Message(strangeEffect.defName + " count: " + strangeEffect.randomEffects.Count);
        //        for (int i = 0; i < strangeEffect.randomEffects.Count; i++)
        //        {
        //            //Log.Message(strangeEffect.defName + " procced");
        //            strangeEffect.randomEffects[i].DoEffect(pawn);
        //        }
        //    }
        //    else
        //    {
        //        Log.Warning(strangeEffect.defName + " had no random effect attached to it");
        //    }
        //}

        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            Utilities.DoRandomOutcome(pawn);
        }

    }
}
