using HarmonyLib;

namespace SouldiersTweaks.Patch
{
    [HarmonyPatch(typeof(WizardTargetDetector), "Awake")]
    class WizardTargetDetectorPatch
    {
        public static void Postfix(WizardTargetDetector __instance)
        {
            var wizardTargetDetectorTweak = (WizardTargetDistanceTweak)Tweaks.GetPatchTweak(typeof(WizardTargetDistanceTweak));
            __instance.m_fRadius = (float) wizardTargetDetectorTweak.Value;
        }
    }
}
