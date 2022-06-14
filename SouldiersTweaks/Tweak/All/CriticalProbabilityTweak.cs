using SouldiersTweaks.Patch;
using System;
using System.Reflection;

namespace SouldiersTweaks
{
    public class CriticalProbabilityTweak : FloatTweak, IPatchTweak
    {
        public CriticalProbabilityTweak() : base("Critical probability", 3)
        {
            DefaultValue = 0.005f;
            Min = 0f;
            Max = 1f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        private float GetCurrentCritPercentModifier()
        {
            Type playerCurrentStatsType = Utility.GetPlayerCurrentStats().GetType();
            FieldInfo m_fCritPercentModifier = playerCurrentStatsType.GetField("m_fCritPercentModifier", BindingFlags.NonPublic | BindingFlags.Instance);


            return (float) m_fCritPercentModifier.GetValue(Utility.GetPlayerCurrentStats());
        }

        private float GetCurrentCritProbabilityModifier()
        {
            Type playerCurrentStatsType = Utility.GetPlayerCurrentStats().GetType();
            FieldInfo m_fCritProbModifier = playerCurrentStatsType.GetField("m_fCritProbModifier", BindingFlags.NonPublic | BindingFlags.Instance);


            return (float) m_fCritProbModifier.GetValue(Utility.GetPlayerCurrentStats());
        }

        private void SetCurrentCritPercentModifier(float value)
        {
            Type playerCurrentStatsType = Utility.GetPlayerCurrentStats().GetType();
            FieldInfo m_fCritPercentModifier = playerCurrentStatsType.GetField("m_fCritPercentModifier", BindingFlags.NonPublic | BindingFlags.Instance);


            m_fCritPercentModifier.SetValue(Utility.GetPlayerCurrentStats(), value);
        }

        private void SetCurrentCritProbabilityModifier(float value)
        {
            Type playerCurrentStatsType = Utility.GetPlayerCurrentStats().GetType();
            FieldInfo m_fCritProbModifier = playerCurrentStatsType.GetField("m_fCritProbModifier", BindingFlags.NonPublic | BindingFlags.Instance);


            m_fCritProbModifier.SetValue(Utility.GetPlayerCurrentStats(), value);
        }

        public override void OnValueApplied()
        {
            SetCurrentCritProbabilityModifier((float) Value);
        }
    }
}
