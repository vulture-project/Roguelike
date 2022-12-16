using Components;

using Leopotam.Ecs;

using UnityEngine;

namespace Systems
{ 
    public class AccelerationSystem : IEcsRunSystem
    {
        private EcsFilter<AccelerationComponent, VelocityComponent, InputComponent> _entities;

        public void Run()
        {
            foreach (var entity in _entities)
            {
                ref var acceleration = ref _entities.Get1(entity);
                ref var velocity = ref _entities.Get2(entity);
                ref var input = ref _entities.Get3(entity);

                var deltaVelocity = acceleration.Value * Time.deltaTime;

                if (!Mathf.Approximately(input.Value.x, 0.0f))
                {
                    var x = velocity.Value.x + input.Value.x * deltaVelocity.x;
                    x = Mathf.Clamp(x, -velocity.MaxValue.x, velocity.MaxValue.x);
                    velocity.Value += Vector3.right * (x - velocity.Value.x) ;
                }

                if (!Mathf.Approximately(input.Value.z, 0.0f))
                {
                    var z = velocity.Value.z + input.Value.z * deltaVelocity.z;
                    z = Mathf.Clamp(z, -velocity.MaxValue.z, velocity.MaxValue.z);
                    velocity.Value += Vector3.forward * (z - velocity.Value.z);
                }
            }
        }
    }
}
