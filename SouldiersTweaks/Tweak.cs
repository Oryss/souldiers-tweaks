using System;
using UnityEngine;

namespace SouldiersTweaks
{
    public abstract class Tweak
    {
        public string Label { get; }
        public string PlayerPrefKey { get; }
        public Tweak(string label, string playerPrefKey)
        {
            Label = label;
            PlayerPrefKey = playerPrefKey;
        }

        public abstract void Render();
        public abstract void Save();
        public abstract void Load();
    }
}
   