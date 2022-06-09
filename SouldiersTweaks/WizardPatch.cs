using HarmonyLib;

namespace SouldiersTweaks
{
    [HarmonyPatch(typeof(WizardTargetDetector), "Awake")]
    class Patch
    {
        public static void Postfix(WizardTargetDetector __instance)
        {
            if (null != Tweaks.PatchValues.WizardTargetDistanceTweakValue)
            {
                __instance.m_fRadius = (float) Tweaks.PatchValues.WizardTargetDistanceTweakValue;
            }
        }
    }
}
