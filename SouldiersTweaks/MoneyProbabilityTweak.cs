namespace SouldiersTweaks
{
    public class MoneyProbabilityTweak : FloatTweak
    {
        public string Description = "Money probability multiplier.";

        public MoneyProbabilityTweak(string label) : base(label, 1f, 0f, 10f, "MoneyProbabilityTweak")
        {
            Value = DefaultValue;
        }

        public override void OnValueChange()
        {
        }
    }
}
