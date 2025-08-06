using RimWorld;

namespace SeldoreXeno
{
    [DefOf]
    public static class StatDefOf
    {
        public static StatDef Stat_LightWeakness;

        static StatDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(StatDefOf));
        }
    }
}
