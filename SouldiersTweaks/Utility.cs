using System.Collections.Generic;

namespace SouldiersTweaks
{
    public class Utility
    {
        public static DifficultyManager.DifficultyLevel GetDifficultyLevel()
        {
            List<DifficultyManager.DifficultyLevel> difficultyLevels = DifficultyManager.s_cInstance.GetDifficultyLevels();

            for (int i = 0; i < difficultyLevels.Count; i++)
            {

                Tweaks.Log(difficultyLevels[i].m_level.ToString());
                Tweaks.Log(difficultyLevels[i].m_enemyLifeMultiplier.ToString());
                if (difficultyLevels[i].m_level == DifficultyManager.s_cInstance.m_currentDifficulty)
                {
                    return difficultyLevels[i];
                }
            }

            return null;
        }

        public static Constants.eCharacters GetPlayerType()
        {
            var playerCurrentStats = PlayerCurrentStats.GetPlayerCurrentStats();
            var baseStats = (PlayerBaseStats) playerCurrentStats.GetBaseStats();
            var characterType = baseStats.characterType;

            return characterType;
        }

        public static bool IsPlayerArcher()
        {
            return GetPlayerType() == Constants.eCharacters.ARCHER;
        }

        public static bool IsPlayerWizard()
        {
            return GetPlayerType() == Constants.eCharacters.WIZARD;
        }

        public static bool IsPlayerSoldier()
        {
            return GetPlayerType() == Constants.eCharacters.SOLDIER;
        }

        public static PlayerCurrentStats GetPlayerCurrentStats()
        {
            var currentStats = PlayerCurrentStats.GetPlayerCurrentStats();

            if (Utility.IsPlayerArcher())
            {
                return (ArcherCurrentStats) currentStats;
            }

            if (Utility.IsPlayerWizard())
            {
                return (WizardCurrentStats) currentStats;
            }

            if (Utility.IsPlayerSoldier())
            {
                return (SoldierCurrentStats) currentStats;
            }

            return currentStats;
        }
    }
}
