using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using System.Collections;

namespace SouldiersTweaks
{
    public class Tweaks : MelonMod
    {
        private bool displayMenu = false;

        // GUI stuff
        Rect windowRect = new Rect(20, 150, 400, 500);
        int windowId = 1;

        public static MelonLogger.Instance loggerInstance;

        private List<Tweak> tweaks = new List<Tweak>()
        {
            new EnemyHealthTweak("Enemy health multiplier"),
            new GroundDodgeCooldownTweak("Ground dodge cooldown"),
        };

        private List<Tweak> archerTweaks = new List<Tweak>()
        {
            new ArcherArrowMissTweak("Disable Archer arrow miss"),
            new ArcherBowThrowDecelerationTweak("Bow Throw Deceleration"),
            new ArcherBowThrowSpeedTweak("Bow Throw Speed"),
            new ArcherBowThrowReturnAccelerationTweak("Bow Throw Return acceleration")
        };

    public static void Log (string message)
        {
            loggerInstance.Msg(message);
        }

        public override void OnApplicationLateStart()
        {
            base.OnApplicationLateStart();

            loggerInstance = LoggerInstance;
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F11))
            {
                Log("Displaying tweaks menu");

                displayMenu = !displayMenu;

                if (displayMenu)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                } else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }

        public override void OnGUI()
        {
            if (!displayMenu) return;

            GUI.color = Color.white;
            GUI.backgroundColor = Color.black;
            GUI.contentColor = Color.white;

            windowRect = GUI.Window(windowId, windowRect, DebugWindow, "Orys' Tweaks");
        }

        void DebugWindow(int windowId)
        {
            foreach (var tweak in tweaks)
            {
                tweak.Render();
            }

            Log(Utility.IsPlayerArcher().ToString());

            if (Utility.IsPlayerArcher())
            {
                foreach (var tweak in archerTweaks)
                {
                    tweak.Render();
                }
            }

            if (GUILayout.Button("Save"))
            {
                foreach (var tweak in tweaks)
                {
                    tweak.Save();
                }
            }

            GUILayout.Space(20);

            if (GUILayout.Button("Load"))
            {
                foreach (var tweak in tweaks)
                {
                    tweak.Load();
                }
            }

            GUILayout.Space(20);

            if (GUILayout.Button("Reset to defaults"))
            {
                foreach (var tweak in tweaks)
                {
                    tweak.Reset();
                }
            }
        }
    }
}
