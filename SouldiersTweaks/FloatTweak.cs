using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SouldiersTweaks
{
    public abstract class FloatTweak : Tweak
    {
        public float? DefaultValue { get; set;  }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public float? Value { get; set; }

        public FloatTweak(string label, string playerPrefKey) : base(label, playerPrefKey)
        {
            Value = DefaultValue;
        }

        public abstract void OnValueChange();

        public override void Render()
        {
            GUI.skin.label.alignment = TextAnchor.UpperLeft;
            GUILayout.BeginHorizontal();

            GUILayout.Label(Label.ToString());

            GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();

                    GUILayout.BeginHorizontal();
                        float selectedValue = GUILayout.HorizontalSlider((float) Value, (float) Min, (float) Max);
                        Value = (float)Math.Round(selectedValue, 1);
                    GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUI.skin.label.alignment = TextAnchor.UpperLeft;
                        GUILayout.Label(Min.ToString());

                        GUI.skin.label.alignment = TextAnchor.UpperCenter;
                        GUILayout.Label(Value.ToString());

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
            }
        }

        public override void Save()
        {
            if (null == Value)
            {
                return;
            }

            OnValueChange();
            PlayerPrefs.SetFloat(PlayerPrefKey, (float) Value);
        }

        public override void Reset()
        {
            Value = DefaultValue;
        }
    }
}
