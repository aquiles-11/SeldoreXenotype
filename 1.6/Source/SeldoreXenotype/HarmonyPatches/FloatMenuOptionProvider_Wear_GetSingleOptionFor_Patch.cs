using HarmonyLib;
using RimWorld;
using Verse;

namespace SeldoreXeno.HarmonyPatches
{
    [HarmonyPatch(typeof(FloatMenuOptionProvider_Wear), "GetSingleOptionFor")]
    public static class FloatMenuOptionProvider_Wear_GetSingleOptionFor_Patch
    {
        public static void Postfix(ref FloatMenuOption __result, Thing clickedThing, FloatMenuContext context)
        {
            if (clickedThing.def.HasModExtension<ApparelBodySpecific_Extension>())
            {
                Apparel apparel = clickedThing as Apparel;

                if (!apparel.def.GetModExtension<ApparelBodySpecific_Extension>().allowedBodyTypeDefs.Contains(context.FirstSelectedPawn.story.bodyType))
                {
                    __result = new FloatMenuOption("SeldoreXenotype.ApparelBodyMismatch".Translate(apparel.Label, apparel), null);
                }
            }
        }
    }
}