using System;
using UnityEngine;

namespace SouldiersTweaks
{
    public abstract class FloatTweak : Tweak
    {
        public float? DefaultValue { get; set;  }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public float? SliderValue { get; set; }
        public float? Value { get; set; }
        public int Decimals { get; set; }

        public FloatTweak(string label, int decimals = 1) : base(label)
        {
            Value = DefaultValue;
            SliderValue = DefaultValue;
            Decimals = decimals;
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
                        float selectedValue = GUILayout.HorizontalSlider((float)SliderValue, (float) Min, (float) Max);
                        SliderValue = (float) Math.Round(selectedValue, Decimals);
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
                Value = PlayerPrefs.GetFloat(PlayerPrefKey);
                SliderValue = PlayerPrefs.GetFloat(PlayerPrefKey);
            }
        }

        public override void Apply()
        {
            Value = SliderValue;

            OnValueApplied();
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(PlayerPrefKey, (float) Value);
        }

        public override void Reset()
        {
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }
    }
}
