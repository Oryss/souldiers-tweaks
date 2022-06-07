using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SouldiersTweaks
{
    public class EnemyHealthTweak : FloatTweak
    {
        public string Description = "Enemy health multiplier. If less than 1, it will reduce the enemy health";

        public EnemyHealthTweak(string label) : base(label, 1f, 0.1f, 5f, "EnemyHealthTweakMultiplier")
        {
            Value = DefaultValue;
        }

        public void UpdateDifficulty()
        {
            
        }

        public override void OnValueChange()
        {
            var difficultyLevel = Utility.GetDifficultyLevel();
            difficultyLevel.m_enemyLifeMultiplier *= Value;
        }
    }
}
