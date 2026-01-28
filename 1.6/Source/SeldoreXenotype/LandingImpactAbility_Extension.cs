using Verse;

namespace SeldoreXeno
{
    public class LandingImpactAbility_Extension : DefModExtension
    {
        public bool damageCaster = false;
        public DamageDef damageDef;
        public DamageDef secondaryDamageDef;
        public int damageAmount = 1;
        public int secondaryDamageAmount = 1;
        public float armorPen = 1f;
        public float screenShake = 1f;
        public float radius;
        public SoundDef explosionSound;
    }
}
