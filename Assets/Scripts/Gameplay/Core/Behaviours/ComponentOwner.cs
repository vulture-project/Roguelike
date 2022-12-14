using Gameplay.Core.Components;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Gameplay.Core.Behaviours
{
    public class ComponentOwner : MonoBehaviour, IComponentOwner
    {
        private const Int32 NotFoundIndex = -1;

        [SerializeField]
        private List<IComponent> _components;

        private void Awake()
        {
            _components = new List<IComponent>();
        }

        public bool Has<TComponent>() where TComponent : class, IComponent
        {
            var index = Find<TComponent>();
            return index != NotFoundIndex;
        }

        public TComponent Get<TComponent>() where TComponent : class, IComponent
        {
            var index = Find<TComponent>();
            if (index == NotFoundIndex)
            {
                return null;
            }
            var component = _components[index] as TComponent;
            return component;
        }

        public bool Add<TComponent>(TComponent component) where TComponent : class, IComponent
        {
            var index = Find<TComponent>();
            if (index != NotFoundIndex)
            {
                return false;
            }
            _components.Add(component);
            return true;
        }

        public bool Remove<TComponent>() where TComponent : class, IComponent
        {
            var index = Find<TComponent>();
            if (index == NotFoundIndex)
            {
                return false;
            }
            _components.RemoveAt(index);
            return true;
        }

        private int Find<TComponent>() where TComponent : class, IComponent
        {
            return _components.FindIndex(component => component is TComponent);
        }
    }
}