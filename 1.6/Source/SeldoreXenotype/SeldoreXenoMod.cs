using HarmonyLib;
using Verse;

namespace SeldoreXeno
{
    public class SeldoreXenoMod : Mod
    {
        public SeldoreXenoMod(ModContentPack content) : base(content)
        {
            Harmony harmony = new Harmony("tobyguilmon.seldorexeno");
            harmony.PatchAll();
            Log.Message("[Crave Saga Xenotype] Patches loaded, ready for adventure!");
        }
    }
}
