namespace SouldiersTweaks
{
    public class ArcherBowThrowSpeedTweak : FloatTweak
    {
        public string Description = "Archer bow throw speed";

        public ArcherBowThrowSpeedTweak(string label) : base(label, 40f, 0f, 500f, "ArcherBowThrowSpeedTweak")
        {
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            var currentStats = (ArcherCurrentStats)PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.GetArcherClassBaseStats().m_fSpinningBow_InitialSpeed = Value;
        }
    }
}
