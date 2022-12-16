using Gameplay.Common.Components;

using Gameplay.Core.Components;
using Gameplay.Core.Systems;

using UnityEngine;

namespace Gameplay.Common.Systems
{
    public class MovementSystem : ISystem
    {
        private Transform _transform;
        private Movement _movement;

        public void OnAdd(GameObject gameObject, IComponentOwner componentOwner)
        {
            _transform = gameObject.transform;
            _movement = componentOwner.Get<Movement>();
        }

        public void OnRemove()
        {
            _movement = null;
        }

        public void OnUpdate()
        {
            _transform.position += _transform.forward * (_movement.Velocity.z * Time.deltaTime) +
                                   _transform.right * (_movement.Velocity.x * Time.deltaTime);
        }
    }
}