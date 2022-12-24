using System;
using UnityComponents;
using UnityEngine;

namespace States
{
    public class IdleState : State
    {
        private SpellBook _spellBook;
        
        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _stateSwitch.SwitchTo(_spellBook.GetPrimaryAttack());
            }
        }

        public override void OnExit()
        {
        }
        
        private void Start()
        {
            _spellBook = GetComponent<SpellBook>();
        }
    }
}