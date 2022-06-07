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
        Rect windowRect = new Rect(20, 20, 400, 400);
        int windowId = 1;

        private List<Tweak> tweaks = new List<Tweak>()
        {
            new EnemyHealthTweak("Enemy health multiplier"),
            new ArcherArrowMissTweak("Disable Archer arrow miss"),

            new ArcherBowThrowDecelerationTweak("Bow Throw Deceleration"),
            new ArcherBowThrowSpeedTweak("Bow Throw Speed"),
            new ArcherBowThrowReturnAccelerationTweak("Bow Throw Return cceleration"),
        };

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F11))
            {
                LoggerInstance.Msg("Displaying tweaks menu");

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
            GUI.DragWindow();

            foreach (var tweak in tweaks)
            {
                tweak.Render();
            }

            if (GUILayout.Button("Save"))
            {
                foreach (var tweak in tweaks)
                {
                    tweak.Save();
                }
            }

            if (GUILayout.Button("Load"))
            {
                foreach (var tweak in tweaks)
                {
                    tweak.Load();
                }
            }
        }
    }
}
