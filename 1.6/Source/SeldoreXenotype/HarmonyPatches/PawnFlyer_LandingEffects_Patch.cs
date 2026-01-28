using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace SeldoreXeno.HarmonyPatches
{
    [HarmonyPatch(typeof(PawnFlyer), "LandingEffects")]
    public static class PawnFlyer_LandingEffects_Patch
    {
        public static bool Prefix(PawnFlyer __instance)
        {
            var ability = __instance.triggeringAbility;

            if (ability != null)
            {
                var modExtension = ability.GetModExtension<LandingImpactAbility_Extension>();

                if (modExtension != null)
                {
                    List<Thing> list = new List<Thing>();

                    if (!modExtension.damageCaster)
                    {
                        list.Add(__instance.FlyingPawn);
                    }

                    GenExplosion.DoExplosion(__instance.DestinationPos.ToIntVec3(), __instance.Map, modExtension.radius, modExtension.damageDef, __instance.FlyingPawn, modExtension.damageAmount, modExtension.armorPen, modExtension.explosionSound, null, null, null, null, 0f, 0, null, null, 255, false, null, 0f, 0, 0f, false, null, list, null, false, 0f, 0f, false);

                    if (modExtension.secondaryDamageDef != null)
                    {
                        GenExplosion.DoExplosion(__instance.DestinationPos.ToIntVec3(), __instance.Map, modExtension.radius, modExtension.secondaryDamageDef, __instance.FlyingPawn, modExtension.secondaryDamageAmount, modExtension.armorPen, null, null, null, null, null, 0f, 0, null, null, 255, false, null, 0f, 0, 0f, false, null, list, null, false, 0f, 0f, false);
                    }
                }
            }

            return true;
        }
    }
}
