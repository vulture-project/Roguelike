using Gameplay.Common.Behaviours;
using Gameplay.Common.Components;

using Gameplay.Core.Components;
using Gameplay.Core.Systems;

using UnityEngine;

namespace Gameplay.Common.Systems
{
    public class OrientatingSystem : ISystem
    {
        private Raycast _raycast;
        private Transform _transform;
        private Movement _movement;

        public void OnAdd(GameObject gameObject, IComponentOwner componentOwner)
        {
            _raycast = gameObject.GetComponent<Raycast>();
            _transform = gameObject.transform;
            _movement = componentOwner.Get<Movement>();
        }

        public void OnRemove()
        {
            _raycast = null;
            _transform = null;
            _movement = null;
        }
        
        public void OnUpdate()
        {
            if (_raycast.WithGround(out var hit))
            {
                _transform.forward = (hit.point - _transform.position).normalized;                
            }
        }
    }
}