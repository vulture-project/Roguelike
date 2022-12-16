using Gameplay.Consumption.Items;

using System.Collections.Generic;

using UnityEngine;

namespace Gameplay.Inventory.Behaviours
{
    public class InventoryOwner : MonoBehaviour
    {
        [SerializeField]
        private List<Consumable> _consumables;

        public List<Consumable> View()
        {
            return _consumables;
        }
        
        public void Add(Consumable consumable)
        {
            _consumables.Add(consumable);
        }

        public void Remove(Consumable consumable)
        {
            _consumables.Remove(consumable);
        }
    }
}