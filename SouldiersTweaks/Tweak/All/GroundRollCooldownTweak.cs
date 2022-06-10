namespace SouldiersTweaks
{
    public class GroundRollCooldownTweak : FloatTweak
    {
        public GroundRollCooldownTweak() : base("Ground roll cooldown")
        {
            DefaultValue = 1.25f;
            Min = 0f;
            Max = 3f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
            var currentStats = PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.m_BaseStats.m_fGroundRollCooldown = (float) Value;
        }
    }
}
