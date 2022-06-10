using SouldiersTweaks.Patch;

namespace SouldiersTweaks
{
    public class XpAmountTweak : FloatTweak, IPatchTweak
    {
        public XpAmountTweak() : base("Xp amount multiplier")
        {
            DefaultValue = 1f;
            Min = 0f;
            Max = 1000f;
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
