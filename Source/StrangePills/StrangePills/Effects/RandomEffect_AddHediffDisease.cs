using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public class RandomEffect_AddHediffDisease : RandomEffect
    {
        public override bool TryDoEffect(Pawn pawn)
        {
            if(canBlock && pawn.health.hediffSet.HasHediff(StrangePillsDefof.PenoxycylineHigh))
            {
                Log.Message("Blocked!");
                return false;
            }
            Hediff hediff = HediffMaker.MakeHediff(this.hediffDef, pawn, null);
            float num = this.hediffDef.initialSeverity;
            hediff.Severity = num;
            if (HediffGiverUtility.TryApply(pawn, hediffDef, null))
            {
                return true;
            }
            return false;
        }

        public HediffDef hediffDef;
        public bool canBlock = false;
    }
}
