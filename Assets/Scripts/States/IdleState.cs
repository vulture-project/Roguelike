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
            if (Input.GetButtonDown("Fire1"))
            {
                                
            }

            if (Input.GetButtonDown("Fire2"))
            {
                
            }
        }

        public override void OnExit()
        {
        }
    }
}