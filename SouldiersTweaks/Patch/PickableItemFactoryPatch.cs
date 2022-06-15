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
            if (PickableItemFactory.IsQuestItem(_type))
            {
                var upgradeItemsAmountTweak = (UpgradeItemsAmountTweak)Tweaks.GetPatchTweak(typeof(UpgradeItemsAmountTweak));

                Constants.eQuestItemType questItemType = PickableItemFactory.GetQuestItemType(_type);
                if (questItemType == Constants.eQuestItemType.RAGNARITA || questItemType == Constants.eQuestItemType.ROKIRITA)
                {
                    _iAmount *= (int)upgradeItemsAmountTweak.Value;
                }
            }
        }
    }
}