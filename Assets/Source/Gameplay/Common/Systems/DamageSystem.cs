using Gameplay.Common.Components;

using Gameplay.Core.Components;
using Gameplay.Core.Systems;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Common.Systems
{
    public class DamageSystem : ISystem
    {
        private Health _health;
        private Damage _damage;
        
        public void OnAdd(GameObject gameObject, IComponentOwner componentOwner)
        {
            _health = componentOwner.Get<Health>();
            _damage = componentOwner.Get<Damage>();
        }

        public void OnRemove()
        {
        }

        public void OnUpdate()
        {
            _health.Damage(_damage.Value);
            _damage.Value = 0;
        }
    }
}