namespace SouldiersTweaks
{
    public class EnemyHealthTweak : FloatTweak
    {
        public EnemyHealthTweak() : base("Enemy health multiplier")
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
            difficultyLevel.m_enemyLifeMultiplier = (float) Value;
        }
    }
}
