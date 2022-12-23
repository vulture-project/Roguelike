using UnityEngine;

namespace States
{
    public class IdleState : State
    {
        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
            if (Input.GetButtonDown("Fire1")) _stateSwitch.SwitchTo<ProjectileCastingState>();
            if (Input.GetButtonDown("Fire2")) _stateSwitch.SwitchTo<SpellMaintainingState>();
        }

        public override void OnExit()
        {
        }
    }
}