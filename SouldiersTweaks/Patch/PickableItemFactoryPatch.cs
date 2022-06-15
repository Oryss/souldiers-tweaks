using BattleDefs;
using HarmonyLib;
using System;

namespace SouldiersTweaks.Patch
{
    [HarmonyPatch(typeof(PickableItemFactory), "PickItem")]
    class PickableItemFactoryPatch
	{
        public static void Prefix(Constants.ePickableItem _type, ref int _iAmount, EnumQuestMapIconsID _cQuestMapIDs = EnumQuestMapIconsID.NONE, bool silenceMode = false)
        {
            Tweaks.Log(_type.ToString());

            if (PickableItemFactory.IsQuestItem(_type))
            {
                var upgradeItemsAmountTweak = (UpgradeItemsAmountTweak)Tweaks.GetPatchTweak(typeof(UpgradeItemsAmountTweak));

                Constants.eQuestItemType questItemType = PickableItemFactory.GetQuestItemType(_type);
                Tweaks.Log(questItemType.ToString());
                Tweaks.Log(_iAmount.ToString());

                if (_type.ToString() == Constants.eQuestItemType.RAGNARITA.ToString() || _type.ToString() == Constants.eQuestItemType.ROKIRITA.ToString())
                {
                    _iAmount *= (int)upgradeItemsAmountTweak.Value;
                }
            }
        }
    }
}