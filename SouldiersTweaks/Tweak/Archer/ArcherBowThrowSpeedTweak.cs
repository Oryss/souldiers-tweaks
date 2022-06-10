namespace SouldiersTweaks
{
    public class ArcherBowThrowSpeedTweak : FloatTweak
    {
        public ArcherBowThrowSpeedTweak() : base("Bow Throw Speed")
        {
            DefaultValue = 40f;
            Min = 0f;
            Max = 500f;
            Value = DefaultValue;
        }

        public override void OnValueSave()
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
