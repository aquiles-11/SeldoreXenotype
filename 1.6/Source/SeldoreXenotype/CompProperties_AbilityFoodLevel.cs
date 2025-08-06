using RimWorld;

namespace SeldoreXeno
{
    public class CompProperties_AbilityFoodLevel : CompProperties_AbilityEffect
    {
        public float offset = 0;

        public CompProperties_AbilityFoodLevel()
        {
            compClass = typeof(CompAbilityEffect_FoodLevel);
        }
    }
}