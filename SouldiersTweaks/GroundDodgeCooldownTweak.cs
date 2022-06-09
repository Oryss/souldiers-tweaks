namespace SouldiersTweaks
{
    public class GroundDodgeCooldownTweak : FloatTweak
    {
        public string Description = "Dodge cooldown";

        public GroundDodgeCooldownTweak(string label) : base(label, "GroundDodgeCooldownTweak")
        {
            DefaultValue = 1.25f;
            Min = 0f;
            Max = 5f;
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            if (Value == null)
            {
                return;
            }

            var currentStats = PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.m_BaseStats.m_fGroundRollCooldown = (float) Value;
        }
    }
}
