using SouldiersTweaks.Patch;
using System;
using System.Reflection;

namespace SouldiersTweaks
{
    public class CriticalPercentMultiplierTweak : FloatTweak, IPatchTweak
    {
        public CriticalPercentMultiplierTweak() : base("Critical damage multiplier")
        {
            DefaultValue = 1f;
            Min = 0f;
            Max = 5f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        private float GetCurrentCritPercentModifier()
        {
            Type playerCurrentStatsType = Utility.GetPlayerCurrentStats().GetType();
            FieldInfo m_fCritPercentModifier = playerCurrentStatsType.GetField("m_fCritPercentModifier", BindingFlags.NonPublic | BindingFlags.Instance);


            return (float) m_fCritPercentModifier.GetValue(Utility.GetPlayerCurrentStats());
        }

        private void SetCurrentCritPercentModifier(float value)
        {
            Type playerCurrentStatsType = Utility.GetPlayerCurrentStats().GetType();
            FieldInfo m_fCritPercentModifier = playerCurrentStatsType.GetField("m_fCritPercentModifier", BindingFlags.NonPublic | BindingFlags.Instance);


            m_fCritPercentModifier.SetValue(Utility.GetPlayerCurrentStats(), value);
        }

        public override void OnValueApplied()
        {
            SetCurrentCritPercentModifier((float) Value);
        }
    }
}
