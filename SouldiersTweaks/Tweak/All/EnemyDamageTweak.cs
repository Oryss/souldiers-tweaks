namespace SouldiersTweaks
{
    public class EnemyDamageTweak : FloatTweak
    {
        public EnemyDamageTweak() : base("Enemy damage multiplier")
        {
            DefaultValue = 1f;
            Min = 0.1f;
            Max = 5f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
            var difficultyLevel = Utility.GetDifficultyLevel();
            difficultyLevel.m_enemyDamageMultiplier = (float) Value;
        }
    }
}
