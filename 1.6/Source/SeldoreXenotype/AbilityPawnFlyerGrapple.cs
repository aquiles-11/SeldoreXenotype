using UnityEngine;
using VEF.Abilities;
using Verse;

namespace SeldoreXeno
{
    [StaticConstructorOnStartup]
    public class AbilityPawnFlyerGrapple : AbilityPawnFlyer
    {
        private static readonly string RopeTexPath = "Misc/SummitSnare";
        private static readonly Material RopeLineMat = MaterialPool.MatFrom(RopeTexPath, ShaderDatabase.Transparent, GenColor.FromBytes(255, 255, 255));

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
        }

        protected override void DrawAt(Vector3 drawLoc, bool flip = false)
        {
            base.DrawAt(drawLoc, flip);

            GenDraw.DrawLineBetween(DrawPos, DestinationPos, AltitudeLayer.PawnRope.AltitudeFor(), RopeLineMat);
        }

        public override void DrawGUIOverlay()
        {
            Vector2 pos = LabelDrawPosFor(this, FlyingPawn, -0.6f);
            GenMapUI.DrawPawnLabel(FlyingPawn, pos);
        }

        public static Vector2 LabelDrawPosFor(Thing thing, Pawn heldPawn, float worldOffsetZ)
        {
            Vector3 drawPos = thing.DrawPos;
            drawPos.z += worldOffsetZ;
            Vector2 result = Find.Camera.WorldToScreenPoint(drawPos) / Prefs.UIScale;
            result.y = UI.screenHeight - result.y;

            if (!heldPawn.RaceProps.Humanlike)
                result.y -= 4f;
            else if (heldPawn.DevelopmentalStage.Baby())
                result.y -= 8f;
            return result;
        }
    }
}
