using SouldiersTweaks.Patch;

namespace SouldiersTweaks
{
    public class XpAmountTweak : FloatTweak, IPatchTweak
    {
        public XpAmountTweak() : base("Xp amount multiplier")
        {
            DefaultValue = 1f;
            Min = 0f;
            Max = 100f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
        }
    }
}
