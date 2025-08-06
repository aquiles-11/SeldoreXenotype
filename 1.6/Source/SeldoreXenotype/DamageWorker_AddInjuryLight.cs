using RimWorld;
using Verse;

namespace SeldoreXeno
{
    public class DamageWorker_AddInjuryLight : DamageWorker_AddInjury
    {
        public override DamageResult Apply(DamageInfo dinfo, Thing thing)
        {
            float pawnLightWeakness = thing.GetStatValue(StatDefOf.Stat_LightWeakness);

            if (pawnLightWeakness > 0)
            {
                dinfo.SetAmount(dinfo.Amount * (pawnLightWeakness + 1));
            }

            return base.Apply(dinfo, thing);
        }
    }
}