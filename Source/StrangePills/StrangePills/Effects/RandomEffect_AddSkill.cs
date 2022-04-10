using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StrangePills
{
    public class RandomEffect_AddSkill : RandomEffect
    {
        
        public override bool TryDoEffect(Pawn pawn)
        {
            SkillRecord record = pawn.skills.GetSkill(skill);
            if (!record.TotallyDisabled && record.levelInt < 20)
            {
                pawn.skills.Learn(skill, amount, true);
                return true;
            }
            return false;
        }

        SkillDef skill;
        float amount = 0f;
    }
}
