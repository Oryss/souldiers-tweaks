using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SouldiersTweaks
{
    public class ArcherBowThrowDecelerationTweak : FloatTweak
    {
        public string Description = "Archer bow throw deceleration";

        public ArcherBowThrowDecelerationTweak(string label) : base(label, -100f, -500f, 500f, "ArcherBowThrowDecelerationTweak")
        {
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            var currentStats = (ArcherCurrentStats)PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.GetArcherClassBaseStats().m_fSpinningBow_InitialDeceleration = Value;
        }
    }
}
