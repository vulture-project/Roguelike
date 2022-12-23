using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class MovementInputSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _filter;


        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var input = ref _filter.Get1(i);

                input.Value = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            }
        }
    }
}