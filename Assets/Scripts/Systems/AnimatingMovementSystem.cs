using Components;

using Leopotam.Ecs;

using UnityEngine;

namespace Gameplay.Common.Systems
{
    public class AnimatingMovementSystem : IEcsSystem
    {
        private Animator _animator;
        private int _velocityXHash;
        private int _velocityZHash;
        private Movement _movement;

        public void OnAdd(GameObject gameObject, IComponentOwner componentOwner)
        {
            _animator = gameObject.GetComponent<Animator>();
            _velocityXHash = Animator.StringToHash("velocityX");
            _velocityZHash = Animator.StringToHash("velocityZ");
            _movement = componentOwner.Get<Movement>();

        }

        public void OnRemove()
        {
            _animator = null;
            _velocityXHash = 0;
            _velocityZHash = 0;
            _movement = null;
        }
        
        public void OnUpdate()
        {
            _animator.SetFloat(_velocityXHash, _movement.Velocity.x);
            _animator.SetFloat(_velocityZHash, _movement.Velocity.z);
        }
    }
}