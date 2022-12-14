using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Consumption.Items
{
    public class Consumable : ScriptableObject
    {
        public virtual void Consume(GameObject gameObject, IComponentOwner componentOwner)
        {
        }
    }
}