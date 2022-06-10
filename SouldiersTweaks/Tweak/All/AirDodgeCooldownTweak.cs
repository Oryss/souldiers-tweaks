namespace SouldiersTweaks
{
    public class AirRollCooldownTweak : FloatTweak
    {
        public AirRollCooldownTweak() : base("Air roll cooldown")
        {
            DefaultValue = 1.8f;
            Min = 0f;
            Max = 3f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
            var currentStats = PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.m_BaseStats.m_fAirRollCooldown = (float) Value;
        }
    }
}
