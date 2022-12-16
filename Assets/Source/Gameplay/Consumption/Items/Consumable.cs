using System;
using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Consumption.Items
{
    public class Consumable : ScriptableObject
    {
        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private string _description;

        public Sprite Icon()
        {
            return _icon;
        }

        public string Description()
        {
            return _description;
        }
        
        public virtual void Consume(GameObject gameObject, IComponentOwner componentOwner)
        {
        }
    }
}