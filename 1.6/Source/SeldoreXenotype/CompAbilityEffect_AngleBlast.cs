using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace SeldoreXeno
{
    public class CompAbilityEffect_AngleBlast : CompAbilityEffect
    {
        public new CompProperties_AbilityAngleBlast Props => (CompProperties_AbilityAngleBlast)props;

        private Pawn Pawn => parent.pawn;

        private readonly List<IntVec3> tmpCells = new List<IntVec3>();

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            IntVec3 cell = target.Cell;
            Map mapHeld = parent.pawn.MapHeld;

            IntVec3 position = Pawn.Position;
            float num = Mathf.Atan2((float)(-(float)(target.Cell.z - position.z)), (float)(cell.x - position.x)) * Props.angleMultiplier;
            FloatRange value = new FloatRange(num - Props.addedAngle, num + Props.addedAngle);

            parent.AddEffecterToMaintain(Props.effect.Spawn(position, cell, parent.pawn.Map, 1f), position, cell, Props.effectTickAwayFromCast, Pawn.MapHeld);
            GenExplosion.DoExplosion(position, mapHeld, Props.range, Props.damageDef, Pawn, Props.damageAmount, -1f, null, null, null, null, Props.filth, 1f, 1, null, null, 255, false, null, 0f, 1, Props.makeFlame, false, null, null, new FloatRange?(value), false, Props.explosionSpeed, 0f, false, null, Props.screenShake);
            base.Apply(target, dest);
        }
        public override void DrawEffectPreview(LocalTargetInfo target)
        {
            GenDraw.DrawFieldEdges(AffectedCells(target));
        }

        public override bool AICanTargetNow(LocalTargetInfo target)
        {
            if (Pawn.Faction != null)
            {
                foreach (IntVec3 c in AffectedCells(target))
                {
                    List<Thing> thingList = c.GetThingList(Pawn.Map);
                    for (int i = 0; i < thingList.Count; i++)
                    {
                        if (thingList[i].Faction == Pawn.Faction)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private List<IntVec3> AffectedCells(LocalTargetInfo target)
        {
            tmpCells.Clear();
            Vector3 val = Pawn.Position.ToVector3Shifted().Yto0();
            IntVec3 intVec = target.Cell.ClampInsideMap(Pawn.Map);
            if (Pawn.Position == intVec)
            {
                return tmpCells;
            }
            float lengthHorizontal = (intVec - Pawn.Position).LengthHorizontal;
            float num = (float)(intVec.x - Pawn.Position.x) / lengthHorizontal;
            float num2 = (float)(intVec.z - Pawn.Position.z) / lengthHorizontal;
            intVec.x = Mathf.RoundToInt((float)Pawn.Position.x + num * Props.range);
            intVec.z = Mathf.RoundToInt((float)Pawn.Position.z + num2 * Props.range);
            float num3 = Vector3.SignedAngle(intVec.ToVector3Shifted().Yto0() - val, Vector3.right, Vector3.up);
            float num4 = Props.lineWidthEnd / 2f;
            float num5 = Mathf.Sqrt(Mathf.Pow((intVec - Pawn.Position).LengthHorizontal, 2f) + Mathf.Pow(num4, 2f));
            float num6 = 57.29578f * Mathf.Asin(num4 / num5);
            int num7 = GenRadial.NumCellsInRadius(Props.range);
            for (int i = 0; i < num7; i++)
            {
                IntVec3 intVec2 = Pawn.Position + GenRadial.RadialPattern[i];
                if (CanUseCell(intVec2) && Mathf.Abs(Mathf.DeltaAngle(Vector3.SignedAngle(intVec2.ToVector3Shifted().Yto0() - val, Vector3.right, Vector3.up), num3)) <= num6)
                {
                    tmpCells.Add(intVec2);
                }
            }
            List<IntVec3> list = GenSight.BresenhamCellsBetween(Pawn.Position, intVec);
            for (int j = 0; j < list.Count; j++)
            {
                IntVec3 intVec3 = list[j];
                if (!tmpCells.Contains(intVec3) && CanUseCell(intVec3))
                {
                    tmpCells.Add(intVec3);
                }
            }
            return tmpCells;
        }

        bool CanUseCell(IntVec3 c)
        {
            if (!c.InBounds(Pawn.Map))
            {
                return false;
            }
            if (c == Pawn.Position)
            {
                return false;
            }
            if (c.Filled(Pawn.Map))
            {
                return false;
            }
            if (!c.InHorDistOf(Pawn.Position, Props.range))
            {
                return false;
            }
            ShootLine resultingLine;
            return parent.verb.TryFindShootLineFromTo(parent.pawn.Position, c, out resultingLine);
        }
    }

}
