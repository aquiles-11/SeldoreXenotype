using HarmonyLib;
using RimWorld;
using Verse;

namespace SeldoreXeno.HarmonyPatches
{
    [HarmonyPatch(typeof(Apparel), "PawnCanWear")]
    public static class Apparel_PawnCanWear_Patch
    {
        public static void Postfix(ref bool __result, ref Apparel __instance, Pawn pawn, bool ignoreGender = false)
        {
            if (__instance.def.HasModExtension<ApparelBodySpecific_Extension>())
            {
                if (!__instance.def.GetModExtension<ApparelBodySpecific_Extension>().allowedBodyTypeDefs.Contains(pawn.story.bodyType))
                {
                    __result = false;
                }
            }
        }
    }
}
