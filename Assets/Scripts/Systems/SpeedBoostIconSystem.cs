using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class SpeedBoostIconSystem : IEcsRunSystem
    {
        private EcsFilter<SpeedBoostComponent, SpeedBoostIconComponent> _filter;
        private GameObject _icon;
        private bool _is_active = false;
        
        public void Run()
        {
            if (_filter.GetEntitiesCount() > 0)
            {
                var icon = _filter.Get2(0);
                icon.Icon.SetActive(true);
                _icon = icon.Icon;
                _is_active = true;
            }
            else if (_is_active)
            {
                _icon.SetActive(false);
                _is_active = false;
            }
        }
    }
}