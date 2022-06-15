using SouldiersTweaks.Patch;

namespace SouldiersTweaks
{
    public class UpgradeItemsAmountTweak : IntTweak, IPatchTweak
    {
        public UpgradeItemsAmountTweak() : base("Upgrade items quantity multiplier")
        {
            DefaultValue = 1;
            Min = 0;
            Max = 10;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
            Value = (int) Value;
        }
    }
}
