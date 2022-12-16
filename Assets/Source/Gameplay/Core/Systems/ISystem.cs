using Gameplay.Core.Components;
using UnityEngine;

namespace Gameplay.Core.Systems
{
    public interface ISystem
    {
        public void OnAdd(GameObject gameObject, IComponentOwner componentOwner);
        
        public void OnRemove();

        public void OnUpdate();
    }
}