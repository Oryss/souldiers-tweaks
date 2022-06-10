namespace SouldiersTweaks
{
    public class GroundDodgeCooldownTweak : FloatTweak
    {
        public GroundDodgeCooldownTweak() : base("Ground dodge cooldown")
        {
            DefaultValue = 1.25f;
            Min = 0f;
            Max = 3f;
            Value = DefaultValue;
        }

        public override void OnValueSave()
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
