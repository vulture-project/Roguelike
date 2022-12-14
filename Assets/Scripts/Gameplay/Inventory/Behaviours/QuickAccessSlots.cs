using Gameplay.Consumption.Items;
using Gameplay.Consumption.States;

namespace Gameplay.Inventory.Behaviours
{
    public class QuickAccessSlots
    {
        private ItemConsumptionState _firstSlot;
        private ItemConsumptionState _secondSlot;
        private ItemConsumptionState _thirdSlot;
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