using RimWorld;
using Verse;

namespace SeldoreXeno
{
    public class CompAbilityEffect_FoodLevel : CompAbilityEffect
    {
        public new CompProperties_AbilityFoodLevel Props => (CompProperties_AbilityFoodLevel)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Pawn pawn = target.Pawn;
            if (pawn.needs?.food != null)
            {
                pawn.needs.food.CurLevel += (Props.offset);
            }
        }

        public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
        {
            return Valid(target);
        }
    }
}