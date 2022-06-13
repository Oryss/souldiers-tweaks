using HutongGames.PlayMaker;

namespace SouldiersTweaks
{
    public class GravityTweak : FloatTweak
    {
        public GravityTweak() : base("Gravity")
        {
            DefaultValue = -80f;
            Min = -80f;
            Max = 100f;
            Value = DefaultValue;
            SliderValue = DefaultValue;
        }

        public override void OnValueApplied()
        {
            var fsm = Utility.GetPlayerFsm();

            FsmFloat gravityVariable = fsm.FsmVariables.GetFsmFloat("DEFAULT_GRAVITY_ACCEL");
            gravityVariable.Value = (float) Value;
        }
    }
}
