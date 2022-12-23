using Components;
using Factories;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class DropSystem : IEcsRunSystem
    {
        private EcsFilter<TransformComponent, PotionDropTag, DestroyTag> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var transform = _filter.Get1(i).Transform;

                if (Random.Range(0, 1) < 1f)
                {
                    float potionOption = Random.Range(0, 3);

                    if (potionOption < 1)
                    {
                        HealPotionFactory.Instance().Spawn(transform.position);
                    } else if (potionOption < 2)
                    {
                        ManaPotionFactory.Instance().Spawn(transform.position);
                    } else if (potionOption < 3)
                    {
                        SpeedPotionFactory.Instance().Spawn(transform.position);
                    }
                }
            }
        }
    }
}