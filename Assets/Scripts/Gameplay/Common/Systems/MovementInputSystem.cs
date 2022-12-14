using Gameplay.Core.Components;
using Gameplay.Core.Systems;

using Gameplay.Common.Components;

using UnityEngine;

namespace Gameplay.Common.Systems
{
    public class MovementInputSystem : ISystem
    {
        private Movement _movement;

        public void OnAdd(GameObject gameObject, IComponentOwner componentOwner)
        {
            _movement = componentOwner.Get<Movement>();                            
        }

        public void OnRemove()
        {
            _movement = null;
        }

        public void OnUpdate()
        {
            _movement.Input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        }
    }
}