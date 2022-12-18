using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class NavMeshMovementSystem : IEcsRunSystem
    {
        private EcsFilter<NavMeshAgentComponent, TransformComponent, VelocityComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var navMeshAgent = ref _filter.Get1(i);
                ref var transform = ref _filter.Get2(i);
                ref var velocity = ref _filter.Get3(i);
                
                Vector3 actual_velocity = navMeshAgent.NavMeshAgent.velocity;
                Vector3 forward_vector = transform.Transform.forward;
                Vector3 right_vector = transform.Transform.right;

                velocity.Value.x = Vector3.Dot(right_vector, actual_velocity);
                velocity.Value.z = Vector3.Dot(forward_vector, actual_velocity);
            }
        }
    }
}