namespace SouldiersTweaks
{
    public class ArcherBowThrowReturnAccelerationTweak : FloatTweak
    {
        public string Description = "Archer bow throw return acceleration";

        public ArcherBowThrowReturnAccelerationTweak(string label) : base(label, "ArcherBowThrowReturnAccelerationTweak")
        {
            DefaultValue = 50f;
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
            currentStats.GetArcherClassBaseStats().m_fSpinningBow_ReturnAcceleration = (float) Value;
        }
    }
}
