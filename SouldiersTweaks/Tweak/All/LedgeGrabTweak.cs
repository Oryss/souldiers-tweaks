using SouldiersTweaks.Patch;

namespace SouldiersTweaks
{
    public class LedgeGrabTweak : ToggleTweak, IPatchTweak
    {
        public LedgeGrabTweak() : base("Disable automatic ledge grab")
        {
            Active = false;
        }

        public override void OnActivate()
        {
            Active = true;
        }

        public override void OnDeactivate()
        {
            Active = false;
        }
    }
}
