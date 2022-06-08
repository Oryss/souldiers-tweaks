using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SouldiersTweaks
{
    public class GroundDodgeCooldownTweak : FloatTweak
    {
        public string Description = "Dodge cooldown";

        public GroundDodgeCooldownTweak(string label) : base(label, 1.25f, 0f, 5f, "GroundDodgeCooldownTweak")
        {
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            var currentStats = PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.m_BaseStats.m_fGroundRollCooldown = Value;
        }
    }
}
