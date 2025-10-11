using HarmonyLib;
using RimWorld;
using Verse;

namespace SeldoreXeno.HarmonyPatches
{
    [HarmonyPatch(typeof(EquipmentUtility), "CanEquip", [typeof(Thing), typeof(Pawn), typeof(string), typeof(bool)],
    [ArgumentType.Normal, ArgumentType.Normal, ArgumentType.Out, ArgumentType.Normal])]
    public static class EquipmentUtility_CanEquip_Patch
    {
        public static void Postfix(ref bool __result, Thing thing, Pawn pawn, ref string cantReason, bool checkBonded = true)
        {
            if (thing.def.IsApparel && thing.def.HasModExtension<ApparelBodySpecific_Extension>())
            {
                Apparel apparel = thing as Apparel;

                if (!apparel.def.GetModExtension<ApparelBodySpecific_Extension>().allowedBodyTypeDefs.Contains(pawn.story.bodyType))
                {
                    cantReason = "SeldoreXenotype.ForceTargetApparelBodyMismatch".Translate(apparel.Label, apparel);
                    __result = false;
                }
            }
        }
    }
}