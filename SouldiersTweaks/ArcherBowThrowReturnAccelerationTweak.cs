namespace SouldiersTweaks
{
    public class ArcherBowThrowReturnAccelerationTweak : FloatTweak
    {
        public string Description = "Archer bow throw return acceleration";

        public ArcherBowThrowReturnAccelerationTweak(string label) : base(label, 50f, 0f, 500f, "ArcherBowThrowReturnAccelerationTweak")
        {
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            if (!Utility.IsPlayerArcher())
            {
                return;
            }

            var currentStats = (ArcherCurrentStats)PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.GetArcherClassBaseStats().m_fSpinningBow_ReturnAcceleration = Value;
        }
    }
}
