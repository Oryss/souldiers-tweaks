namespace SouldiersTweaks
{
    public class WizardTargetDistanceTweak : FloatTweak
    {
        public string Description = "Wizard target distance";

        public WizardTargetDistanceTweak(string label) : base(label, "WizardTargetDistanceTweak")
        {
            DefaultValue = 100f;
            Min = 0f;
            Max = 1000f;
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            if (Value == null)
            {
                return;
            }

            Tweaks.PatchValues.WizardTargetDistanceTweakValue = (float) Value;
        }
    }
}
