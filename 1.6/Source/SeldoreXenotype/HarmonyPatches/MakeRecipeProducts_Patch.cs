using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace SeldoreXeno.HarmonyPatches
{
    [HarmonyPatch(typeof(GenRecipe), "MakeRecipeProducts")]
    public static class MakeRecipeProducts_Patch
    {
        private static void Postfix(IEnumerable<Thing> __result, RecipeDef recipeDef, Pawn worker, List<Thing> ingredients, Thing dominantIngredient, IBillGiver billGiver)
        {
            if (worker.InspirationDef != SeldoreDefOf.Inspired_ChefRecommendation)
            {
                return;
            }

            if (worker.InspirationDef.HasModExtension<CookingInspiration_Extension>())
            {
                if (!worker.InspirationDef.GetModExtension<CookingInspiration_Extension>().cookingRecipesList.Contains(recipeDef))
                {
                    return;
                }
            }

            foreach (Thing item in __result)
            {
                item.def = SeldoreDefOf.MealLavish;
            }
        }
    }
}
