using Gameplay.Core.Systems;

using System.Collections.Generic;
using Gameplay.Core.Components;
using UnityEngine;

namespace Gameplay.Core.Behaviours
{
    [RequireComponent(typeof(ComponentOwner))]
    public class SystemExecutor : MonoBehaviour
    {
        private IComponentOwner _componentOwner;
        
        private List<ISystem> _systems;

        private void Awake()
        {
            _componentOwner = gameObject.GetComponent<ComponentOwner>();
            _systems = new List<ISystem>();
        }

        private void Update()
        {
            foreach (var system in _systems)
            {
                system.OnUpdate();
            }
        }
        
        public bool Add(ISystem system)
        {
            if (_systems.Contains(system))
            {
                return false;
            }
            _systems.Add(system);
            system.OnAdd(gameObject, _componentOwner);
            return true;
        }

        public bool Remove(ISystem system)
        {
            if (!_systems.Contains(system))
            {
                return false;
            }
            system.OnRemove();
            _systems.Remove(system);
            return true;
        }
    }
}