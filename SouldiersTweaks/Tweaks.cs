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

        // Tweaks which needs to be accessed from patches
        public static WizardTargetDistanceTweak wizardTargetDistanceTweakInstance;
        public static MoneyAmountTweak moneyAmountTweak;
        public static MoneyProbabilityTweak moneyProbabilityTweak;

        private List<Tweak> tweaks = new List<Tweak>()
        {
            new EnemyHealthTweak("Enemy health multiplier"),
            new GroundDodgeCooldownTweak("Ground dodge cooldown"),
            new MoneyProbabilityTweak("Money probability multiplier"),
            new MoneyAmountTweak("Money amount multiplier"),
        };

        private List<Tweak> archerTweaks = new List<Tweak>()
        {
            new ArcherArrowMissTweak("Disable Archer arrow miss"),
            new ArcherBowThrowDecelerationTweak("Bow Throw Deceleration"),
            new ArcherBowThrowSpeedTweak("Bow Throw Speed"),
            new ArcherBowThrowReturnAccelerationTweak("Bow Throw Return acceleration")
        };

        private List<Tweak> wizardTweaks = new List<Tweak>()
        {
            new WizardTargetDistanceTweak("Wizard attack range"),
        };

        public static void Log(string message)
        {
            loggerInstance.Msg(message);
        }

        public override void OnApplicationLateStart()
        {
            base.OnApplicationLateStart();

            loggerInstance = LoggerInstance;

            moneyProbabilityTweak = (MoneyProbabilityTweak)tweaks[2];
            moneyAmountTweak = (MoneyAmountTweak)tweaks[3];
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F11))
            {
                GlobalSceneManager.m_cInstance.m_bActiveIngameCheats = true;
                GUIManager.mInstance.activate(EnumGUILayers.GUILayer_IngameCheats, true, false, 0);

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

        public static Dictionary<string, object> GetPatchValues() => new Dictionary<string, object>
        {
            { wizardTargetDistanceTweakInstance.PlayerPrefKey , wizardTargetDistanceTweakInstance.Value },
            { moneyProbabilityTweak.PlayerPrefKey , moneyProbabilityTweak.Value },
            { moneyAmountTweak.PlayerPrefKey , moneyAmountTweak.Value },
        };
        public static bool GetBooleanPatchValueByPlayerPrefKey(string playerPrefKey) => (bool)GetPatchValues()[playerPrefKey];
        public static float GetFloatPatchValueByPlayerPrefKey(string playerPrefKey) {
            var val = GetPatchValues()[playerPrefKey];
           return (float)val;
        }

        public static object GetPatchValueByPlayerPrefKey(string playerPrefKey) => GetPatchValues()[playerPrefKey];

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

            if (Utility.IsPlayerArcher())
            {
                foreach (var archerTweak in archerTweaks)
                {
                    archerTweak.Render();
                }
            }

            if (Utility.IsPlayerWizard())
            {
                foreach (var wizardTweak in wizardTweaks)
                {
                    wizardTweak.Render();
                }
            }

            if (GUILayout.Button("Save"))
            {
                foreach (var tweak in tweaks)
                {
                    tweak.Save();
                }

                if (Utility.IsPlayerArcher())
                {
                    foreach (var archerTweak in archerTweaks)
                    {
                        archerTweak.Save();
                    }
                }

                if (Utility.IsPlayerWizard())
                {
                    foreach (var wizardTweak in wizardTweaks)
                    {
                        wizardTweak.Save();
                    }
                }
            }

            GUILayout.Space(20);

            if (GUILayout.Button("Load"))
            {
                foreach (var tweak in tweaks)
                {
                    tweak.Load();
                }

                if (Utility.IsPlayerArcher())
                {
                    foreach (var archerTweak in archerTweaks)
                    {
                        archerTweak.Load();
                    }
                }

                if (Utility.IsPlayerWizard())
                {
                    foreach (var wizardTweak in wizardTweaks)
                    {
                        wizardTweak.Load();
                    }
                }
            }

            GUILayout.Space(20);

            if (GUILayout.Button("Reset to defaults"))
            {
                foreach (var tweak in tweaks)
                {
                    tweak.Reset();
                }

                if (Utility.IsPlayerArcher())
                {
                    foreach (var archerTweak in archerTweaks)
                    {
                        archerTweak.Reset();
                    }
                }

                if (Utility.IsPlayerWizard())
                {
                    foreach (var wizardTweak in wizardTweaks)
                    {
                        wizardTweak.Reset();
                    }
                }
            }
        }
    }
}
