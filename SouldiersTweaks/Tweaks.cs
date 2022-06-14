using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MelonLoader;
using SouldiersTweaks.Patch;
using UnityEngine;
using UnityEngine.SceneManagement;

// Orys' tweaks mod

namespace SouldiersTweaks
{
    public class Tweaks : MelonMod
    {
        private bool displayMenu = false;

        Rect windowRect = new Rect(20, 150, 850, 750);
        int windowId = 1;
        GUIStyle paddingStyle = new GUIStyle() { padding = new RectOffset() { right = 10, left = 10 } };

        public static MelonLogger.Instance loggerInstance;

        private static List<Tweak> tweaks = new List<Tweak>()
        {
            new EnemyHealthTweak(),
            new EnemyDamageTweak(),
            new PlayerDamageTweak(),
            new GroundRollCooldownTweak(),
            new AirRollCooldownTweak(),
            new MoneyProbabilityTweak(),
            new MoneyAmountTweak(),
            new XpAmountTweak(),
            new ShieldRecoveryTweak(),
            new GravityTweak(),
            new CriticalProbabilityTweak(),
            new CriticalPercentMultiplierTweak(),
            new CriticalHitBulletTimeTweak(),
        };

        private static List<Tweak> archerTweaks = new List<Tweak>()
        {
            new ArcherArrowMissTweak(),
            new ArcherNormalArrowCooldownTweak(),
            new ArcherMaxNormalArrowsTweak(),
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
            if (Input.GetKeyDown(KeyCode.F11) && !Input.GetKey(KeyCode.LeftControl))
            {
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

            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F11))
            {
                GUIManager.mInstance.activate(EnumGUILayers.GUILayer_IngameCheats);
            }
        }

        public static void SkipIntro()
        {
            var layers = new List<EnumGUILayers>()
            {
                EnumGUILayers.GUILayer_Loading,
                EnumGUILayers.GUILayer_Splash,
                EnumGUILayers.GUILayer_Splash_AnimeVideo,
                EnumGUILayers.GUILayer_Splash_Retroforge,
                EnumGUILayers.GUILayer_Splash_Nave,
            };

            foreach (var layer in layers)
            {
                try
                {
                    GUIManager.mInstance.deactivate(layer);
                } catch {
                    Log("Error when trying to deactivate layer " + layer.ToString());
                }
            }

            GUIManager.mInstance.activate(EnumGUILayers.GUILayer_MainMenu);
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
            RenderTweaks();

            GUILayout.BeginHorizontal();
                if (GUILayout.Button("Apply"))
                    CallOnAllTweaks("Apply");
                GUILayout.FlexibleSpace();

            if (GUILayout.Button("Reset to defaults"))
                CallOnAllTweaks("Reset");

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Save"))
                CallOnAllTweaks("Save");
            GUILayout.Space(20);
            if (GUILayout.Button("Load"))
                CallOnAllTweaks("Load");

            GUILayout.EndHorizontal();
        }

        private void RenderTweaks()
        {
            GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();
                    GUI.skin.label.alignment = TextAnchor.MiddleCenter;
                    GUILayout.Label("General");
                    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
                    foreach (var tweak in tweaks)
                    {
                        tweak.Render();
                    }
                    GUILayout.FlexibleSpace();
                GUILayout.EndVertical();

                GUILayout.BeginVertical();
                    GUI.skin.label.alignment = TextAnchor.MiddleCenter;
                    GUILayout.Label("Class-specific");
                    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
                    RenderClassSpecificTweaks();
                    GUILayout.FlexibleSpace();
                GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        private void RenderClassSpecificTweaks()
        {
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
        }

        public void CallOnAllTweaks(string methodName)
        {
            Type type = typeof(Tweak);
            MethodInfo methodInfo = type.GetMethod(methodName);

            if (null == methodInfo)
            {
                return;
            }

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
