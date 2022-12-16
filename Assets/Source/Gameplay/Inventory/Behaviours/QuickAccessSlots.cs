using Gameplay.Consumption.Items;
using Gameplay.Consumption.States;

using UnityEngine;

namespace Gameplay.Inventory.Behaviours
{
    public class QuickAccessSlots : MonoBehaviour
    {
        [SerializeField]
        private ItemConsumptionState _firstSlot;
        
        [SerializeField]
        private ItemConsumptionState _secondSlot;

        [SerializeField]
        private ItemConsumptionState _thirdSlot;

        [SerializeField]
        private ItemConsumptionState _fourthSlot;

        public void SetConsumableToFirstSlot(Consumable consumable)
        {
            _firstSlot.SetConsumable(consumable);
        }

        public void SetConsumableToSecondSlot(Consumable consumable)
        {
            _secondSlot.SetConsumable(consumable);
        }
        
        public void SetConsumableToThirdSlot(Consumable consumable)
        {
            _thirdSlot.SetConsumable(consumable);
        }
        
        public void SetConsumableToFourthSlot(Consumable consumable)
        {
            _fourthSlot.SetConsumable(consumable);
        }
    }
}