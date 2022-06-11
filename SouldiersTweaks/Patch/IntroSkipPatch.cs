using HarmonyLib;

namespace SouldiersTweaks.Patch
{
    [HarmonyPatch(typeof(GUIManager), "activate")]
    class IntroSkipPatch
    {
        public static void Postfix(EnumGUILayers _eGUILayer, bool isUnique = true, bool _bChangeLayerOrder = false, int _iNewLayerOrder = 0)
        {
            if (EnumGUILayers.GUILayer_Splash_AnimeVideo == _eGUILayer)
            {
                Tweaks.SkipIntro();
            }
        }
    }
}