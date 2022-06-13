using System;
using UnityEngine;

namespace SouldiersTweaks
{
    public abstract class IntTweak : Tweak
    {
        public int? DefaultValue { get; set;  }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int? SliderValue { get; set; }
        public int? Value { get; set; }

        public IntTweak(string label) : base(label)
        {
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public abstract void OnValueApplied();

        public override void Render()
        {
            GUI.skin.label.alignment = TextAnchor.UpperLeft;
            GUILayout.BeginHorizontal(new GUIStyle() { padding = new RectOffset() { right = 10, left = 10 } });

            GUILayout.Label(Label.ToString(), GUILayout.Width(200));

            GUILayout.BeginHorizontal(GUILayout.Width(200));

            GUILayout.BeginVertical();

                    GUILayout.BeginHorizontal();
                        float selectedValue = GUILayout.HorizontalSlider((int)SliderValue, (int) Min, (int) Max);
                        SliderValue = (int) Math.Round(selectedValue);
                    GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUI.skin.label.alignment = TextAnchor.UpperLeft;
                        GUILayout.Label(Min.ToString());

                        GUI.skin.label.alignment = TextAnchor.UpperCenter;
                        GUILayout.Label(SliderValue.ToString() + " ( " + Value.ToString() + " )");

                        GUI.skin.label.alignment = TextAnchor.UpperRight;
                        GUILayout.Label(Max.ToString());

                        GUI.skin.label.alignment = TextAnchor.UpperLeft;
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();

                GUILayout.EndHorizontal();
            GUILayout.EndHorizontal();
        }

        public override void Load()
        {
            if (PlayerPrefs.HasKey(PlayerPrefKey))
            {
                Value = PlayerPrefs.GetInt(PlayerPrefKey);
                SliderValue = PlayerPrefs.GetInt(PlayerPrefKey);
            }
        }

        public override void Apply()
        {
            Value = SliderValue;

            OnValueApplied();
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(PlayerPrefKey, (int) Value);
        }

        public override void Reset()
        {
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }
    }
}
