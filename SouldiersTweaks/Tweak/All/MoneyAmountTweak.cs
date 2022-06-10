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
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
        }
    }
}
