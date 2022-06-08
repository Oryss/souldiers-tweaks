namespace SouldiersTweaks
{
    public class MoneyAmountTweak : FloatTweak
    {
        public string Description = "Money amount multiplier.";

        public MoneyAmountTweak(string label) : base(label, 1f, 0f, 100f, "MoneyAmountTweak")
        {
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
        }
    }
}
