using Gameplay.Common.Components;

using Gameplay.Core.Components;
using Gameplay.Core.Systems;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Common.Systems
{
    public class DeathChecker : ISystem
    {
        private Animator _animator;
        private int _deathBlowTriggerHash;

        private Health _health;

        public void OnAdd(GameObject gameObject, IComponentOwner componentOwner)
        {
            _animator = gameObject.GetComponent<Animator>();
            _deathBlowTriggerHash = Animator.StringToHash("deathBlow");
            _health = componentOwner.Get<Health>();
        }

        public void OnRemove()
        {
        }

        public void OnUpdate()
        {
            if (Mathf.Approximately(_health.Value(), 0f))
            {
                _animator.SetTrigger(_deathBlowTriggerHash);
            }
        }
    }
}