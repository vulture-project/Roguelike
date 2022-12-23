using System;
using States;
using UnityEngine;

namespace UnityComponents
{
    public class SpellBook : MonoBehaviour
    {
        [SerializeField]
        private State _primaryAttack;

        [SerializeField]
        private State _secondaryAttack;

        public State GetPrimaryAttack()
        {
            return _primaryAttack;
        }

        public State GetSecondaryAttack()
        {
            return _secondaryAttack;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
            }
        }
    }
}