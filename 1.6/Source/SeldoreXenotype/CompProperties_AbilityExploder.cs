using RimWorld;
using Verse;

namespace SeldoreXeno
{
    public class CompProperties_AbilityExploder : CompProperties_AbilityExplosion
    {
        public bool explosionOnCaster = false;

        public bool damageCaster = true;

        public EffecterDef effect;

        public int effectTickAwayFromCast = 1;

        public CompProperties_AbilityExploder()
        {
            compClass = typeof(CompAbilityEffect_Exploder);
        }
    }
}