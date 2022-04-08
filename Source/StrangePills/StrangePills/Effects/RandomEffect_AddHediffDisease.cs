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
		//public override void DoEffect(Pawn pawn)
  //      {
		//	Hediff hediff = HediffMaker.MakeHediff(this.hediffDef, pawn, null);
		//	float num = this.hediffDef.initialSeverity;
		//	hediff.Severity = num;
		//	pawn.health.AddHediff(hediff, null, null, null);
		//}

        public override bool TryDoEffect(Pawn pawn)
        {
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
    }
}
