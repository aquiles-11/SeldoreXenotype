using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace SeldoreXeno.HarmonyPatches
{
    [HarmonyPatch(typeof(Projectile), "ImpactSomething")]
    public static class Projectile_ImpactSomething_Patch
    {
        public static bool Prefix(Projectile __instance, LocalTargetInfo ___usedTarget, Thing ___launcher)
        {
            var thing = ___usedTarget.Thing;

            if (thing is not Pawn pawn || pawn.kindDef.RaceProps.IsMechanoid)
            {
                return true;
            }

            if (pawn.story == null)
            {
                return true;
            }

            if (pawn.health.hediffSet.HasHediff(SeldoreDefOf.HombreRebound))
            {
                GenClamor.DoClamor(pawn, 2.1f, ClamorDefOf.Impact);
                FleckMaker.Static(pawn.Position, pawn.Map, FleckDefOf.ShotFlash);
                SoundDefOf.MetalHitImportant.PlayOneShot(pawn);
                float damageHalved = __instance.def.projectile.GetDamageAmount(__instance.equipment) / 2;
                pawn.Drawer.Notify_DamageDeflected(new DamageInfo(__instance.def.projectile.damageDef, damageHalved));
                pawn.TakeDamage(new DamageInfo(__instance.def.projectile.damageDef, damageHalved));

                ___launcher.TakeDamage(new DamageInfo(__instance.def.projectile.damageDef, damageHalved));
                __instance.Destroy();
            }
            else
            {
                return true;
            }

            return false;
        }
    }
}
