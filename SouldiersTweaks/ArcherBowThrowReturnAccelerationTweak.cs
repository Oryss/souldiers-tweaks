using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SouldiersTweaks
{
    public class ArcherBowThrowReturnAccelerationTweak : FloatTweak
    {
        public string Description = "Archer bow throw deceleration";

        public ArcherBowThrowReturnAccelerationTweak(string label) : base(label, 50f, 0f, 500f, "ArcherBowThrowReturnAccelerationTweak")
        {
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            var currentStats = (ArcherCurrentStats)PlayerCurrentStats.GetPlayerCurrentStats();
            currentStats.GetArcherClassBaseStats().m_fSpinningBow_ReturnAcceleration = Value;
        }
    }
}
