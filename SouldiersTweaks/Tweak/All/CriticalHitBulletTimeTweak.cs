using SouldiersTweaks.Patch;

namespace SouldiersTweaks
{
    public class CriticalHitBulletTimeTweak : ToggleTweak, IPatchTweak
    {
        public CriticalHitBulletTimeTweak() : base("Disable critical hit bullet time")
        {
            Active = false;
        }

        public override void Apply()
        {

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