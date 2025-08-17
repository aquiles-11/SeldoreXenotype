using RimWorld;

namespace SeldoreXeno
{
    public class CompProperties_AbilityExploder : CompProperties_AbilityExplosion
    {
        public bool explosionOnCaster = false;

        public CompProperties_AbilityExploder()
        {
            compClass = typeof(CompAbilityEffect_Exploder);
        }
    }
}