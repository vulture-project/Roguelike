using UnityEngine;

namespace States
{
    public class MovementState : State
    {
        private IStateSwitch _stateSwitch;
    
        public override void OnStart(IStateSwitch stateSwitch)
        {
            _stateSwitch = stateSwitch;
        }
    
        public override void OnEnter()
        {
        }
    
        public override void OnUpdate()
        {
            if (Input.GetButton("Fire1"))
            {
                _stateSwitch.SwitchTo<CastingProjectileState>();
            }
            if (Input.GetButton("Fire2"))
            {
                _stateSwitch.SwitchTo<CastingSelfBuffState>();
            }
        }

        public override void OnExit()
        {
        }
    }
}