using HarmonyLib;

namespace SouldiersTweaks.Patch
{
    [HarmonyPatch(typeof(LootHandler), "Awake")]
    class LootHandlerPatch
    {
        public static void Postfix(LootHandler __instance)
        {
            var moneyProbabilityTweak = (MoneyProbabilityTweak)Tweaks.GetPatchTweak(typeof(MoneyProbabilityTweak));
            var moneyAmountTweak = (MoneyAmountTweak)Tweaks.GetPatchTweak(typeof(MoneyAmountTweak));
            var xpAmountTweak = (XpAmountTweak)Tweaks.GetPatchTweak(typeof(XpAmountTweak));

            if (null != __instance)
            {
                if (null != __instance.money)
                {
                    if (null != moneyProbabilityTweak.Value)
                    {
                        __instance.money.m_fprob *= (float) moneyProbabilityTweak.Value;
                    }

                    if (null != moneyAmountTweak.Value)
                    {
                        __instance.money.m_fAmount *= (float) moneyAmountTweak.Value;
                    }
                }

                if (null != xpAmountTweak.Value)
                {
                    __instance.baseXP = (int)System.Math.Round(__instance.baseXP * (float) xpAmountTweak.Value);
                }


            }
        }
    }
}