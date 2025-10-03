using RimWorld;
using Verse;

namespace SeldoreXeno
{
    public class CompProperties_AbilityGiveSpecificInspiration : CompProperties_AbilityEffect
    {
        public InspirationDef inspirationDef;

        public CompProperties_AbilityGiveSpecificInspiration()
        {
            compClass = typeof(CompAbilityEffect_GiveSpecificInspiration);
        }
    }
}
