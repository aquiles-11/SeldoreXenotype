using RimWorld;
using Verse;

namespace SeldoreXeno
{
    public class CompProperties_AbilityAngleBlast : CompProperties_AbilityEffect
    {
        public float range;

        public float lineWidthEnd;

        public DamageDef damageDef;

        public EffecterDef effect;

        public float screenShake = 1f;

        public ThingDef filth = null;

        public int damageAmount = 1;

        public float armorPen = 1f;

        public float addedAngle = 10f;

        public float angleMultiplier = 57.29578f;

        public float explosionSpeed = 1f;

        public float makeFlame = 0f;

        public int effectTickAwayFromCast = 1;

        public CompProperties_AbilityAngleBlast()
        {
            compClass = typeof(CompAbilityEffect_AngleBlast);
        }
    }
}
