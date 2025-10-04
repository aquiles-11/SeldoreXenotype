using RimWorld;
using Verse;

namespace SeldoreXeno
{
    public class CompAbilityEffect_GiveSpecificInspiration : CompAbilityEffect_GiveInspiration
    {
        public new CompProperties_AbilityGiveSpecificInspiration Props => (CompProperties_AbilityGiveSpecificInspiration) props;
        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Pawn pawn = target.Pawn;
            if (pawn != null)
            {
                if (Props.inspirationDef != null)
                {
                    pawn.mindState.inspirationHandler.TryStartInspiration(Props.inspirationDef, "LetterPsychicInspiration".Translate(pawn.Named("PAWN"), parent.pawn.Named("CASTER")));
                }
            }
        }
    }
}
