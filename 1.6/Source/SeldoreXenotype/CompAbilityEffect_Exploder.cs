using RimWorld;
using UnityEngine;
using Verse;

namespace SeldoreXeno
{
    public class CompAbilityEffect_Exploder : CompAbilityEffect
    {
        public new CompProperties_AbilityExploder Props => (CompProperties_AbilityExploder)props;

        private Pawn Pawn => parent.pawn;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            int num = Props.damageAmount;
            float num2 = Props.armorPenetration;
            if (num == -1)
            {
                num = Props.damageDef.defaultDamage;
            }
            if (Mathf.Approximately(num2, -1f))
            {
                num2 = Props.damageDef.defaultArmorPenetration;
            }
            IntVec3 position = Props.explosionOnCaster ? Pawn.Position : target.Cell;
            //if (target.Pawn is Corpse)
            //{
            //    return;
            //}
            Map mapHeld = Pawn.MapHeld;
            float explosionRadius = Props.explosionRadius;
            DamageDef damageDef = Props.damageDef;
            Pawn pawn = Pawn;
            int damAmount = num;
            float armorPenetration = num2;
            SoundDef soundExplode = Props.soundExplode;
            ThingDef weapon = parent.verb?.EquipmentSource?.def;
            ThingDef postExplosionSpawnThingDef = Props.postExplosionSpawnThingDef;
            ThingDef postExplosionSpawnThingDefWater = Props.postExplosionSpawnThingDefWater;
            float postExplosionSpawnChance = Props.postExplosionSpawnChance;
            int postExplosionSpawnThingCount = Props.postExplosionSpawnThingCount;
            GasType? postExplosionGasType = Props.postExplosionGasType;
            ThingDef preExplosionSpawnThingDef = Props.preExplosionSpawnThingDef;
            float preExplosionSpawnChance = Props.preExplosionSpawnChance;
            int preExplosionSpawnThingCount = Props.preExplosionSpawnThingCount;
            bool applyDamageToExplosionCellsNeighbors = Props.applyDamageToExplosionCellsNeighbors;
            float explosionChanceToStartFire = Props.explosionChanceToStartFire;
            bool explosionDamageFalloff = Props.explosionDamageFalloff;
            float expolosionPropagationSpeed = Props.damageDef.expolosionPropagationSpeed;
            float screenShakeFactor = Props.screenShakeFactor;
            bool doExplosionVFX = Props.doExplosionVFX;
            ThingDef preExplosionSpawnSingleThingDef = Props.preExplosionSpawnSingleThingDef;
            ThingDef postExplosionSpawnSingleThingDef = Props.postExplosionSpawnSingleThingDef;
            GenExplosion.DoExplosion(position, mapHeld, explosionRadius, damageDef, pawn, damAmount, armorPenetration, soundExplode, weapon, null, null, postExplosionSpawnThingDef, postExplosionSpawnChance, postExplosionSpawnThingCount, postExplosionGasType, null, 255, applyDamageToExplosionCellsNeighbors, preExplosionSpawnThingDef, preExplosionSpawnChance, preExplosionSpawnThingCount, explosionChanceToStartFire, explosionDamageFalloff, null, null, null, doExplosionVFX, expolosionPropagationSpeed, 0f, doSoundEffects: true, postExplosionSpawnThingDefWater, screenShakeFactor, null, null, postExplosionSpawnSingleThingDef, preExplosionSpawnSingleThingDef);
        }

        public override void DrawEffectPreview(LocalTargetInfo target)
        {
            GenDraw.DrawRadiusRing(target.Cell, Props.explosionRadius);
        }
    }
}