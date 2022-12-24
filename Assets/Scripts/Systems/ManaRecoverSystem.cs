using Components;
using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace Systems
{
    public class ManaRecoverSystem : IEcsRunSystem
    {
        private EcsFilter<ManaComponent> _filter;

        private const float Value = 10;
        private float _time = 0f;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var mana = ref _filter.Get1(i);

                _time += Time.deltaTime;
                if (_time > 1f)
                {
                    mana.Value = (int)Mathf.Clamp(Value + mana.Value, 0, mana.MaxValue);
                    _time = 0;
                }
            }
        }
    }
}