using SouldiersTweaks.Patch;

namespace SouldiersTweaks
{
    public class MoneyProbabilityTweak : FloatTweak, IPatchTweak
    {
        public MoneyProbabilityTweak() : base("Money probability multiplier")
        {
            DefaultValue = 1f;
            Min = 0f;
            Max = 5f;
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
