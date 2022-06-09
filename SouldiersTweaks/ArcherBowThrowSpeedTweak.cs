namespace SouldiersTweaks
{
    public class ArcherBowThrowSpeedTweak : FloatTweak
    {
        public string Description = "Archer bow throw speed";

        public ArcherBowThrowSpeedTweak(string label) : base(label, "ArcherBowThrowSpeedTweak")
        {
            DefaultValue = 40f;
            Min = 0f;
            Max = 500f;
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            if (Value == null)
            {
                return;
            }

            var currentStats = (ArcherCurrentStats)PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.GetArcherClassBaseStats().m_fSpinningBow_InitialSpeed = (float) Value;
        }
    }
}
