using HarmonyLib;

namespace SouldiersTweaks
{
    [HarmonyPatch(typeof(LootHandler), "Awake")]
    class LootHandlerPatch
    {
        public static void Postfix(LootHandler __instance)
        {
            Tweaks.Log(Tweaks.GetFloatPatchValueByPlayerPrefKey("MoneyProbabilityTweak").ToString());
            Tweaks.Log(Tweaks.GetFloatPatchValueByPlayerPrefKey("MoneyAmountTweak").ToString());

            if (false)
            {
                __instance.money.m_fprob = Tweaks.GetFloatPatchValueByPlayerPrefKey("MoneyProbabilityTweak");
                __instance.money.m_fAmount = Tweaks.GetFloatPatchValueByPlayerPrefKey("MoneyAmountTweak");
            }
        }
    }
}