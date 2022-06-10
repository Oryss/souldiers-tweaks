using System;
using UnityEngine;

namespace SouldiersTweaks
{
    public abstract class ToggleTweak : Tweak
    {
        public bool ToggleActive { get; set; }
        public bool Active { get; set; }

        public ToggleTweak(string label) : base(label)
        {
            ToggleActive = false;
            Active = false;
        }

        public abstract void OnActivate();
        public abstract void OnDeactivate();
        public override void Load()
        {
            if (PlayerPrefs.HasKey(PlayerPrefKey))
            {
                ToggleActive = Convert.ToBoolean(PlayerPrefs.GetInt(PlayerPrefKey));
                Active = Convert.ToBoolean(PlayerPrefs.GetInt(PlayerPrefKey));
            }
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(PlayerPrefKey, Active ? 1 : 0);
        }
        
        public override void Apply()
        {
            Active = ToggleActive;
        }

        public void Activate()
        {
            ToggleActive = true;
            OnActivate();
        }

        public void Deactivate()
        {
            ToggleActive = false;
            OnDeactivate();
        }

        public override void Render()
        {
            ToggleActive = GUILayout.Toggle(ToggleActive, Label);

            if (ToggleActive)
            {
                Activate();
            } 
            else
            {
                Deactivate();
            }
        }

        public override void Reset()
        {
            ToggleActive = false;
            Active = false;
        }
    }
}
