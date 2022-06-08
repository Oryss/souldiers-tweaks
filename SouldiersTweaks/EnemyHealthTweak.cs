namespace SouldiersTweaks
{
    public class EnemyHealthTweak : FloatTweak
    {
        public string Description = "Enemy health multiplier. If less than 1, it will reduce the enemy health";

        public EnemyHealthTweak(string label) : base(label, 1f, 0.1f, 5f, "EnemyHealthTweakMultiplier")
        {
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            var difficultyLevel = Utility.GetDifficultyLevel();
            Tweaks.Log("Changing enemy life multiplier, old value : " + difficultyLevel.m_enemyLifeMultiplier.ToString());
            difficultyLevel.m_enemyLifeMultiplier = Value;
            Tweaks.Log("New value : " + difficultyLevel.m_enemyLifeMultiplier.ToString());
        }
    }
}
