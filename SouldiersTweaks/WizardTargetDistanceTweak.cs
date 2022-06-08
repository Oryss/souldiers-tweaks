using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SouldiersTweaks
{
    public class WizardTargetDistanceTweak : FloatTweak
    {
        public string Description = "Wizard target distance";

        public WizardTargetDistanceTweak(string label) : base(label, 100f, 0f, 1000f, "WizardTargetDistanceTweak")
        {
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            return;
        }
    }
}
