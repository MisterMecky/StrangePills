using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public class RandomEffect_Amnesia : RandomEffect
    {
        public override bool TryDoEffect(Pawn pawn)
        {
            List<Thought_Memory> memories = pawn.needs.mood.thoughts.memories.Memories;
            foreach(var m in memories)
            {
                pawn.needs.mood.thoughts.memories.RemoveMemory(m);
            }
            return true;
        }
    }
}
