using HarmonyLib;
using Verse;

namespace SeldoreXeno.HarmonyPatches
{
    [HarmonyPatch(typeof(GenRecipe), "PostProcessProduct")]
    public static class GenRecipe_PostProcessProduct_Patch
    {
        public static void Postfix(ref Thing __result, Thing product, RecipeDef recipeDef, Pawn worker)
        {
            if (worker.InspirationDef != SeldoreDefOf.Inspired_ChefRecommendation)
            {
                return;
            }

            if (!worker.InspirationDef.HasModExtension<CookingInspiration_Extension>() && !worker.InspirationDef.GetModExtension<CookingInspiration_Extension>().cookingRecipesList.Contains(recipeDef))
            {
                return;
            }

            __result.def = SeldoreDefOf.MealLavish;
            worker.mindState.inspirationHandler.EndInspiration(SeldoreDefOf.Inspired_ChefRecommendation);
        }
    }
}
