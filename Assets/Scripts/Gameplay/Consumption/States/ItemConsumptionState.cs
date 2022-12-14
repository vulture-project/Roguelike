using System;
using Gameplay.Core.States;

using Gameplay.Consumption.Items;
using Gameplay.Core.Behaviours;
using Gameplay.Core.Components;
using UnityEngine;

namespace Gameplay.Consumption.States
{
    [RequireComponent(typeof(ComponentOwner))]
    public class ItemConsumptionState : State
    {
        [SerializeField]
        private ConsumableBase _consumable;

        private IComponentOwner _componentOwner;        
        
        private void Awake()
        {
            _componentOwner = gameObject.GetComponent<ComponentOwner>();
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
    }
}