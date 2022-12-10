using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class CastingProjectileState : IState
    {
        private IStateful _stateful;
        [SerializeField] private GameObject _projectilePrefab;
        
        public CastingProjectileState(IStateful stateful)
        {
            _stateful = stateful;
        }

        public void Update()
        {
            
        }
    }
}