namespace SouldiersTweaks
{
    public class MoneyAmountTweak : FloatTweak
    {
        public string Description = "Money amount multiplier.";

        public MoneyAmountTweak(string label) : base(label, "MoneyAmountTweak")
        {
            DefaultValue = 1f;
            Min = 0f;
            Max = 100f;
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
            if (Value == null)
            {
                return;
            }

            Tweaks.PatchValues.MoneyAmountTweakValue = (float) Value;
        }
    }
}
