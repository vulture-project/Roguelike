using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private EcsFilter<TransformComponent, VelocityComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transform = ref _filter.Get1(i);
                ref var velocity = ref _filter.Get2(i);

                transform.Transform.position += transform.Transform.forward * (velocity.Value.z * Time.deltaTime) +
                                                transform.Transform.right * (velocity.Value.x * Time.deltaTime);
            }
        }
    }
}