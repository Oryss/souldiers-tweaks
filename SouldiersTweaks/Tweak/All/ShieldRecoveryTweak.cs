using System;
using System.Reflection;

namespace SouldiersTweaks
{
    public class ShieldRecoveryTweak : FloatTweak
    {
        public ShieldRecoveryTweak() : base("Shield Recovery")
        {
            DefaultValue = 2f;
            Min = 0f;
            Max = 10f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        private FieldInfo GetBaseSpeedFieldInfo()
        {
            Type playerCurrentStatsType = Utility.GetPlayerCurrentStats().GetType();
            FieldInfo m_fHealShieldBaseSpeedInfo = playerCurrentStatsType.GetField("m_fHealShieldBaseSpeed", BindingFlags.NonPublic | BindingFlags.Instance);

            return m_fHealShieldBaseSpeedInfo;
        }

        private FieldInfo GetNeedRecalculateHealthShieldSpeedFieldInfo()
        {
            Type playerCurrentStatsType = Utility.GetPlayerCurrentStats().GetType();
            FieldInfo m_bNeedRecalculateHealShieldSpeed = playerCurrentStatsType.GetField("m_bNeedRecalculateHealShieldSpeed", BindingFlags.NonPublic | BindingFlags.Instance);

            return m_bNeedRecalculateHealShieldSpeed;
        }

        public override void OnValueApplied()
        {
            GetBaseSpeedFieldInfo().SetValue(Utility.GetPlayerCurrentStats(), (float) Value);

            Tweaks.Log(((float)GetBaseSpeedFieldInfo().GetValue(Utility.GetPlayerCurrentStats())).ToString());

            GetNeedRecalculateHealthShieldSpeedFieldInfo().SetValue(Utility.GetPlayerCurrentStats(), true);
        }
    }
}
