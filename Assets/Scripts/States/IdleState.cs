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
            if (Input.GetButtonDown("Fire2"))
            {
                _stateSwitch.SwitchTo(_spellBook.GetSecondaryAttack());
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