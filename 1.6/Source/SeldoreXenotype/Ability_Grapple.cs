using RimWorld;
using RimWorld.Planet;
using Verse;
using Ability = VEF.Abilities.Ability;

namespace SeldoreXeno
{
    public class Ability_Grapple : Ability
    {
        public override void Cast(params GlobalTargetInfo[] targets)
        {

            foreach (GlobalTargetInfo target in targets)
            {
                IntVec3 destination = this.pawn.Position + ((target.Cell - this.pawn.Position).ToVector3().normalized * 2).ToIntVec3();

                target.Thing.TryGetComp<CompCanBeDormant>()?.WakeUp();

                if (target.Thing is Pawn targetPawn)
                {
                    AbilityPawnFlyerGrapple flyer = (AbilityPawnFlyerGrapple) PawnFlyer.MakeFlyer(SeldoreDefOf.SeldoreGrappleFlyer, targetPawn, destination, null, null);
                    flyer.ability = this;
                    GenSpawn.Spawn(flyer, target.Cell, this.pawn.Map);
                }
                else
                {
                    target.Thing.Position = destination;
                }
            }

            base.Cast(targets);
        }

        public override void CheckCastEffects(GlobalTargetInfo[] targetInfos, out bool cast, out bool target, out bool hediffApply)
        {
            base.CheckCastEffects(targetInfos, out cast, out target, out _);
            hediffApply = false;
        }
    }
}
