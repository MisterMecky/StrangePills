using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public class RandomEffect_AddHediff : RandomEffect
    {
		public override bool TryDoEffect(Pawn pawn)
		{
			//if(pawn.health.hediffSet.HasHediff(hediffDef) && pawn.health.hediffSet.)
   //             {
			//	return false;
   //             }
			Hediff hediff = HediffMaker.MakeHediff(this.hediffDef, pawn, null);
			float num;
			if (this.severity > 0f)
			{
				num = this.severity;
			}
			else
			{
				num = this.hediffDef.initialSeverity;
			}
			AddictionUtility.ModifyChemicalEffectForToleranceAndBodySize(pawn, this.toleranceChemical, ref num);
			hediff.Severity = num;
			pawn.health.AddHediff(hediff, null, null, null);
			return true;
		}

		public HediffDef hediffDef;

        public float severity = -1f;

        public ChemicalDef toleranceChemical;
    }
}
