using HarmonyLib;

namespace SouldiersTweaks
{
    [HarmonyPatch(typeof(WizardTargetDetector), "Awake")]
    class Patch
    {
        public static void Postfix(WizardTargetDetector __instance)
        {
             __instance.m_fRadius = 500f;
        }
    }
}
