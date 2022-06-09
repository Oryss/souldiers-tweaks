namespace SouldiersTweaks
{
    public class EnemyHealthTweak : FloatTweak
    {
        public string Description = "Enemy health multiplier. If less than 1, it will reduce the enemy health";

        public EnemyHealthTweak(string label) : base(label, "EnemyHealthTweakMultiplier")
        {
            DefaultValue = 1f;
            Min = 0.1f;
            Max = 5f;
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            if (Value == null)
            {
                return;
            }

            var difficultyLevel = Utility.GetDifficultyLevel();
            Tweaks.Log("Changing enemy life multiplier, old value : " + difficultyLevel.m_enemyLifeMultiplier.ToString());
            difficultyLevel.m_enemyLifeMultiplier = (float) Value;
            Tweaks.Log("New value : " + difficultyLevel.m_enemyLifeMultiplier.ToString());
        }
    }
}
