using Gameplay.Core.States;

using UnityEngine;

namespace Gameplay.Common.States
{
    public class IdleState : State
    { 
        public override void OnEnter()
        {
        }
    
        public override void OnUpdate()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _stateSwitch.Switch(StateType.PrimaryAttack);                
            }
            if (Input.GetButtonDown("Fire2"))
            {
                _stateSwitch.Switch(StateType.SecondaryAttack);   
            }
        }

        public override void OnExit()
        {
        }
    }
}