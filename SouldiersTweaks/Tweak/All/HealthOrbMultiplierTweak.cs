using SouldiersTweaks.Patch;
using System;
using System.Reflection;

namespace SouldiersTweaks
{
    public class HealthOrbsAmountMultiplierTweak : FloatTweak, IPatchTweak
    {
        public HealthOrbsAmountMultiplierTweak() : base("Health orbs amount multiplier")
        {
            DefaultValue = 1f;
            Min = 0f;
            Max = 5f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
            Value = (float) Value;
        }
    }
}
