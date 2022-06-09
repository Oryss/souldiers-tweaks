namespace SouldiersTweaks
{
    public class ArcherBowThrowDecelerationTweak : FloatTweak
    {
        public string Description = "Archer bow throw deceleration";

        public ArcherBowThrowDecelerationTweak(string label) : base(label, "ArcherBowThrowDecelerationTweak")
        {
            DefaultValue = -100f;
            Min = -500f;
            Max = 500f;
            Value = DefaultValue;
        }

        public override void OnValueChange()
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
