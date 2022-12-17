using Components;

using Leopotam.Ecs;

using UnityEngine;

namespace Systems
{
    public class DecelerationSystem : IEcsRunSystem
    {
        private EcsFilter<AccelerationComponent, VelocityComponent, InputComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var acceleration = ref _filter.Get1(i);
                ref var velocity = ref _filter.Get2(i);
                ref var input = ref _filter.Get3(i);

                var deltaVelocity = acceleration.Value * Time.deltaTime;
                
                if (Mathf.Approximately(input.Value.x, 0.0f))
                {
                    if (0.05 <= velocity.Value.x || velocity.Value.x <= -0.05)
                    {
                        velocity.Value -= Vector3.right * (Mathf.Sign(velocity.Value.x) * deltaVelocity.x);
                    }
                    else
                    {
                        velocity.Value = new Vector3(0f, 0f, velocity.Value.z);
                    }
                }
                
                if (Mathf.Approximately(input.Value.z, 0.0f))
                {
                    if (0.05 <= velocity.Value.z || velocity.Value.z <= -0.05)
                    {
                        velocity.Value -= Vector3.forward * (Mathf.Sign(velocity.Value.z) * deltaVelocity.z);
                    }
                    else
                    {
                        velocity.Value = new Vector3(velocity.Value.x, 0f, 0f);
                    }
                }
            }
        }
    }
}