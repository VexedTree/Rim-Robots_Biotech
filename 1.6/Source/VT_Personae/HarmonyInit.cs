using HarmonyLib;
using System.Reflection;
using Verse;

namespace VT_Personae.HarmonyPatches
{
    [StaticConstructorOnStartup]
    public static class HarmonyInitializer
    {
        static HarmonyInitializer()
        {
            var Harmony = new Harmony("vexedtrees.RimRobotsBiotech");
            Harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
