using HarmonyLib;

namespace SouldiersTweaks
{
    [HarmonyPatch(typeof(LootHandler), "Awake")]
    class LootHandlerPatch
    {
        public static void Postfix(LootHandler __instance)
        {
            if (null != __instance && null != __instance.money)
            {
                if (null != Tweaks.PatchValues.MoneyProbabilityTweakValue)
                {
                    __instance.money.m_fprob *= (float)Tweaks.PatchValues.MoneyProbabilityTweakValue;
                }

                if (null != Tweaks.PatchValues.MoneyAmountTweakValue)
                {
                    __instance.money.m_fAmount *= (float)Tweaks.PatchValues.MoneyAmountTweakValue;
                }
            }
        }
    }
}