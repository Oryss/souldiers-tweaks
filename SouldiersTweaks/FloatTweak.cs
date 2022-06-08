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
        public float DefaultValue { get; set; }
        public float Value { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }

        public FloatTweak(string label, float defaultValue, float min, float max, string playerPrefKey) : base(label, playerPrefKey)
        {
            DefaultValue = defaultValue;
            Value = defaultValue;
            Min = min;
            Max = max;
        }

        public abstract void OnValueChange();

        public override void Render()
        {
            GUI.skin.label.alignment = TextAnchor.UpperLeft;
            GUILayout.Label(Label.ToString());
            float selectedValue = GUILayout.HorizontalSlider(Value, Min, Max);
            Value = (float) Math.Round(selectedValue, 1);

            GUILayout.BeginHorizontal();

            GUI.skin.label.alignment = TextAnchor.UpperLeft;
            GUILayout.Label(Min.ToString());

            GUI.skin.label.alignment = TextAnchor.UpperCenter;
            GUILayout.Label(Value.ToString());

            GUI.skin.label.alignment = TextAnchor.UpperRight;
            GUILayout.Label(Max.ToString());

            GUI.skin.label.alignment = TextAnchor.UpperLeft;

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
            OnValueChange();
            PlayerPrefs.SetFloat(PlayerPrefKey, Value);
        }

        public override void Reset()
        {
            Value = DefaultValue;
        }
    }
}
