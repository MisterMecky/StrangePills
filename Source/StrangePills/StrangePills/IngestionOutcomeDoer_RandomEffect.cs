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
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            throw new NotImplementedException();
        }

        public StrangeEffectDef strangeEffect;
    }
}
