using HarmonyLib;

namespace SouldiersTweaks
{
    [HarmonyPatch(typeof(GUILayer_Intro), "Update")]
    class GUILayer_IntroPatch
    {
        public static void Postfix(GUILayer_Intro __instance)
        {
            __instance.SkipScene();
        }
    }
}
