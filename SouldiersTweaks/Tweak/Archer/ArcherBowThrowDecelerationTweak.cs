namespace SouldiersTweaks
{
    public class ArcherBowThrowDecelerationTweak : FloatTweak
    {
        public ArcherBowThrowDecelerationTweak() : base("Bow Throw Deceleration")
        {
            DefaultValue = -100f;
            Min = -500f;
            Max = 500f;
            Value = DefaultValue;
        }

        public override void OnValueSave()
        {
            if (null == Value)
            {
                return;
            }

            var currentStats = (ArcherCurrentStats)PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.GetArcherClassBaseStats().m_fSpinningBow_InitialDeceleration = (float) Value;
        }
    }
}
