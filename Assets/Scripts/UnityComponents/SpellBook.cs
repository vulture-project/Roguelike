using Factories;
using Prefabs;
using States;

using UnityEngine;

namespace UnityComponents
{
    public class SpellBook : MonoBehaviour
    {
        [SerializeField]
        private State _primaryAttack;

        [SerializeField]
        private ProjectileType _projectileOnAlpha1;

        [SerializeField]
        private ProjectileType _projectileOnAlpha4;
        
        [SerializeField]
        private ProjectileCastingState _projectileCastingState;

        [SerializeField]
        private SelfBuffCastingState _selfBuffCastingState;

        [SerializeField]
        private SpellMaintainingState _spellMaintainingState;
        
        public State GetPrimaryAttack()
        {
            return _primaryAttack;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _primaryAttack = _projectileCastingState;
                _projectileCastingState.SetProjectile(_projectileOnAlpha1);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _primaryAttack = _selfBuffCastingState;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _primaryAttack = _spellMaintainingState;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _primaryAttack = _projectileCastingState;
                _projectileCastingState.SetProjectile(_projectileOnAlpha4);

            }
        }
    }
}