using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MelonLoader;
using SouldiersTweaks.Patch;
using UnityEngine;

namespace SouldiersTweaks
{
    public class Tweaks : MelonMod
    {
        private bool displayMenu = false;

        Rect windowRect = new Rect(20, 150, 450, 600);
        int windowId = 1;

        public static MelonLogger.Instance loggerInstance;
        
        private static List<Tweak> tweaks = new List<Tweak>()
        {
            new EnemyHealthTweak(),
            new GroundRollCooldownTweak(),
            new MoneyProbabilityTweak(),
            new MoneyAmountTweak(),
            new XpAmountTweak(),
        };

        private static List<Tweak> archerTweaks = new List<Tweak>()
        {
            new ArcherArrowMissTweak(),
            new ArcherBowThrowDecelerationTweak(),
            new ArcherBowThrowSpeedTweak(),
            new ArcherBowThrowReturnAccelerationTweak()
        };

        private static List<Tweak> wizardTweaks = new List<Tweak>()
        {
            new WizardTargetDistanceTweak(),
        };

        public static void Log(string message)
        {
            loggerInstance.Msg(message);
        }

        public override void OnApplicationLateStart()
        {
            base.OnApplicationLateStart();

            loggerInstance = LoggerInstance;
        }

        public static List<Tweak> PatchTweaks()
        {
            var patchTweaks = new List<Tweak>();

            patchTweaks.AddRange(tweaks.FindAll(tweak => tweak is IPatchTweak));
            patchTweaks.AddRange(archerTweaks.FindAll(tweak => tweak is IPatchTweak));
            patchTweaks.AddRange(wizardTweaks.FindAll(tweak => tweak is IPatchTweak));

            return patchTweaks;
        }

        public static Tweak GetPatchTweak(Type tweakType)
        {
            return PatchTweaks().First(tweak => tweak.GetType() == tweakType);
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

            windowRect = GUI.Window(windowId, windowRect, TweaksWindow, "Orys' Tweaks");
        }

        void TweaksWindow(int windowId)
        {
            CallOnAllTweaks("Render");

            var buttons = new Dictionary<string, string>()
            {
                { "Apply", "Apply" },
                { "Save", "Save" },
                { "Load", "Load" },
                { "Reset to defaults", "Reset" }
            };

            foreach (var action in buttons)
            {
                if (GUILayout.Button(action.Key))
                    CallOnAllTweaks(action.Value);

                GUILayout.Space(20);
            }
        }

        public void CallOnAllTweaks(string methodName)
        {
            Type type = typeof(Tweak);
            MethodInfo methodInfo = type.GetMethod(methodName);

            foreach (var tweak in tweaks)
            {
                methodInfo.Invoke(tweak, null);
            }

            if (Utility.IsPlayerArcher())
            {
                foreach (var archerTweak in archerTweaks)
                {
                    methodInfo.Invoke(archerTweak, null);
                }
            }

            if (Utility.IsPlayerWizard())
            {
                foreach (var wizardTweak in wizardTweaks)
                {
                    methodInfo.Invoke(wizardTweak, null);
                }
            }
        }
    }
}
