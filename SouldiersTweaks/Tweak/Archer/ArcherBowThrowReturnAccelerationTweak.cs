namespace SouldiersTweaks
{
    public class ArcherBowThrowReturnAccelerationTweak : FloatTweak
    {
        public ArcherBowThrowReturnAccelerationTweak() : base("Bow Throw Return acceleration")
        {
            DefaultValue = 50f;
            Min = 0f;
            Max = 500f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
            var currentStats = (ArcherCurrentStats)PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.GetArcherClassBaseStats().m_fSpinningBow_ReturnAcceleration = (float) Value;
        }
    }
}
