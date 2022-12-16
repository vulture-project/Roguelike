using Gameplay.Common.Components;

using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Consumption.Items
{
    [CreateAssetMenu(fileName = "HealPotion", menuName = "Consumables/HealPotion", order = 53)]
    public class HealPotion : Consumable
    {
        [SerializeField]
        private float _value;

        public override void Consume(GameObject gameObject, IComponentOwner componentOwner)
        {
            if (componentOwner.Get<Health>())
            {
                var health = componentOwner.Get<Health>();
                health.Heal(_value);
            }
        }
    }
}