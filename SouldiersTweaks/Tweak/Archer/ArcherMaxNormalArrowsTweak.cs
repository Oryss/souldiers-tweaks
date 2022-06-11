using System;
using System.Reflection;

namespace SouldiersTweaks
{
    public class ArcherMaxNormalArrowsTweak : IntTweak
    {
        public ArcherMaxNormalArrowsTweak() : base("Max normal arrows")
        {
            DefaultValue = 3;
            Min = 1;
            Max = 10;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
            var currentStats = (ArcherCurrentStats)PlayerCurrentStats.GetPlayerCurrentStats();

            Type type = typeof(ArcherCurrentStats);
            FieldInfo myField = type.GetField("m_iMaxNormalArrows", BindingFlags.NonPublic | BindingFlags.Instance);
            myField.SetValue(currentStats, Value);
        }
    }
}
