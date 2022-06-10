using UnityEngine;

namespace SouldiersTweaks
{
    public class ArcherArrowMissTweak : ToggleTweak
    {
        public ArcherArrowMissTweak() : base("Disable Archer arrow miss")
        {
            Active = false;
        }

        public override void OnActivate()
        {
            if (!GlobalSceneManager.m_cInstance)
            {
                return;
            }

            if (!Utility.IsPlayerArcher())
            {
                return;
            }

            GameObject player = GlobalSceneManager.m_cInstance.m_player;
            if (!player)
            {
                return;
            }

            var playerCurrentStats = PlayerCurrentStats.GetPlayerCurrentStats();

            ArcherCurrentStats archerCurrentStats = playerCurrentStats.GetComponent<ArcherCurrentStats>();
            if (!archerCurrentStats)
            {
                return;
            }

            archerCurrentStats.SetArrowLifeTimeDistance(float.MaxValue);
        }

        public override void OnDeactivate()
        {
            if (!Utility.IsPlayerArcher())
            {
                return;
            }

            if (!GlobalSceneManager.m_cInstance)
            {
                return;
            }

            GameObject player = GlobalSceneManager.m_cInstance.m_player;
            if (!player)
            {
                return;
            }

            // Update the current player stats from the save
            var playerCurrentStats = PlayerCurrentStats.GetPlayerCurrentStats();


            // Get the stats from the save
            var playerStats = SavegameManager.s_cInstance.GetCurrentProfile().GetPlayerStatsData();

            ArcherCurrentStats archerCurrentStats = playerCurrentStats.GetComponent<ArcherCurrentStats>();
            archerCurrentStats.SetArrowLifeTimeDistance(playerStats.m_fArrowLifeTimeDistance);
        }
    }
}
