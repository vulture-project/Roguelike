using Gameplay.Core.States;

using Gameplay.Consumption.Items;

using Gameplay.Core.Behaviours;

using Gameplay.Inventory.Behaviours;

using UnityEngine;

namespace Gameplay.Consumption.States
{
    [RequireComponent(typeof(ComponentOwner), typeof(InventoryOwner))]
    public class ItemConsumptionState : State
    {
        [SerializeField]
        private Consumable _consumable;

        private ComponentOwner _componentOwner;
        private InventoryOwner _inventoryOwner;
        
        private void Awake()
        {
            _componentOwner = gameObject.GetComponent<ComponentOwner>();
            _inventoryOwner = gameObject.GetComponent<InventoryOwner>();
        }
        
        public override void OnEnter()
        {
            _consumable.Consume(gameObject, _componentOwner);
            _stateSwitch.Switch(StateType.Idle);
        }
    
        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }

        public void SetConsumable(Consumable consumable)
        {
            _consumable = consumable;
        }
    }
}