namespace SouldiersTweaks
{
    public class MoneyProbabilityTweak : FloatTweak
    {
        public string Description = "Money probability multiplier.";

        public MoneyProbabilityTweak(string label) : base(label, "MoneyProbabilityTweak")
        {
            DefaultValue = 1f;
            Min = 0f;
            Max = 10f;
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            if (Value == null)
            {
                return;
            }

            Tweaks.PatchValues.MoneyProbabilityTweakValue = (float) Value;
        }
    }
}
