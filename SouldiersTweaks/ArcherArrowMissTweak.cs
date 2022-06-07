using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SouldiersTweaks
{
    public class ArcherArrowMissTweak : ToggleTweak
    {
        public string Description = "Disable arrow missing for the archer";

        public ArcherArrowMissTweak(string label) : base(label, "ArcherArrowMissTweak")
        {
            Active = false;
        }

        public override void OnActivate()
        {
            if (!GlobalSceneManager.m_cInstance)
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
            archerCurrentStats.SetArrowLifeTimeDistance(float.MaxValue);
        }

        public override void OnDeactivate()
        {
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
