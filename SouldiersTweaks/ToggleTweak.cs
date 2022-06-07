using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SouldiersTweaks
{
    public abstract class ToggleTweak : Tweak
    {
        public bool Active { get; set; }

        public ToggleTweak(string label, string playerPrefKey) : base(label, playerPrefKey)
        {
            Active = false;
        }

        public abstract void OnActivate();
        public abstract void OnDeactivate();
        public override void Load()
        {
            if (PlayerPrefs.HasKey(PlayerPrefKey))
            {
                Active = Convert.ToBoolean(PlayerPrefs.GetInt(PlayerPrefKey));
            }
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(PlayerPrefKey, Active ? 1 : 0);
        }

        public void Activate()
        {
            Active = true;
            OnActivate();
        }

        public void Deactivate()
        {
            Active = false;
            OnDeactivate();
        }

        public override void Render()
        {
            Active = GUILayout.Toggle(Active, Label);

            if (Active)
            {
                Activate();
            } else
            {
                Deactivate();
            }
        }
    }
}
