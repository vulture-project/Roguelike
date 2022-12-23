using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class SpeedBoostIconSystem : IEcsSystem
    {
        private EcsFilter<SpeedBoostComponent, SpeedBoostIconComponent> _filter;
        private GameObject _icon;
        
        public void Run()
        {
            if (_filter.GetEntitiesCount() > 0)
            {
                var icon = _filter.Get2(0);
                icon.Icon.SetActive(true);
                _icon = icon.Icon;
            }
            else
            {
                _icon.SetActive(false);
            }
            
        }
    }
}