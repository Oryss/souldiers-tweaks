using BattleDefs;
using HarmonyLib;
using System;

namespace SouldiersTweaks.Patch
{
    [HarmonyPatch(typeof(AttackInfo), MethodType.Constructor, new Type[] { typeof(AttackInfo) })]
    class CriticalHitBulletTimePatch
    {
        public static void Postfix(AttackInfo __instance)
        {
			var tweak = (CriticalHitBulletTimeTweak) Tweaks.GetPatchTweak(typeof(CriticalHitBulletTimeTweak));
			if (tweak.Active) {
				//__instance.m_eBulletTimeOnHit = CombatHelper.BulletTimeLevel.NONE;
				//__instance.m_eBulletTimeOnHitResistance = CombatHelper.BulletTimeLevel.NONE;
				//__instance.m_eBulletTimeOnHitWeakElement = CombatHelper.BulletTimeLevel.NONE;
				//__instance.m_eBulletTimeOnHitStrongElement = CombatHelper.BulletTimeLevel.NONE;
				__instance.m_eBulletTimeOnCriticalHit = CombatHelper.BulletTimeLevel.NONE;
				//__instance.m_eBulletTimeOnBlock = CombatHelper.BulletTimeLevel.NONE;
				//__instance.m_eBulletTimeOnBlockBreak = CombatHelper.BulletTimeLevel.NONE;
				//__instance.m_eBulletTimeOnPerfectBlock = CombatHelper.BulletTimeLevel.NONE;
			}
		}
    }
}