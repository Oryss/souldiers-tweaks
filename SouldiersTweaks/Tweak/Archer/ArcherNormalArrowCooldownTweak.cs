using System;
using System.Reflection;

namespace SouldiersTweaks
{
    public class ArcherNormalArrowCooldownTweak : FloatTweak
    {
        public ArcherNormalArrowCooldownTweak() : base("Arrow Cooldown")
        {
            DefaultValue = 1.75f;
            Min = 0.1f;
            Max = 3;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
            var currentStats = (ArcherCurrentStats)PlayerCurrentStats.GetPlayerCurrentStats();

            Type type = typeof(ArcherCurrentStats);
            FieldInfo myField = type.GetField("m_fNormalArrowsCooldown", BindingFlags.NonPublic | BindingFlags.Instance);
            myField.SetValue(currentStats, (float) Value);
        }
    }
}
