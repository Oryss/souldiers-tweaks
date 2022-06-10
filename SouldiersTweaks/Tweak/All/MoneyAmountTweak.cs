using SouldiersTweaks.Patch;

namespace SouldiersTweaks
{
    public class MoneyAmountTweak : FloatTweak, IPatchTweak
    {
        public MoneyAmountTweak() : base("Money amount multiplier")
        {
            DefaultValue = 1f;
            Min = 0f;
            Max = 10f;
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
