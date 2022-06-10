using SouldiersTweaks.Patch;

namespace SouldiersTweaks
{
    public class WizardTargetDistanceTweak : FloatTweak, IPatchTweak
    {
        public WizardTargetDistanceTweak() : base("Wizard attack range")
        {
            DefaultValue = 10f;
            Min = 0f;
            Max = 200f;
            Value = DefaultValue;
        }

        public override void OnValueSave()
        {
            if (Value == null)
            {
                return;
            }

            Value = (float) Value;
        }
    }
}
