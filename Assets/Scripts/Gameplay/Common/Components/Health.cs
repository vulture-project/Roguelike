using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Common.Components
{
    [CreateAssetMenu(fileName = "Health", menuName = "Component/Health", order = 52)]
    public class Health : ComponentBase
    {
        [SerializeField]
        private float _value;
        
        [SerializeField]
        private float _maxValue;

        public float Value()
        {
            return _value;
        }

        public void Damage(float value)
        {
            _value = Mathf.Clamp(_value - value, 0, _value);
        }

        public void Heal(float value)
        {
            _value = Mathf.Clamp(_value + value, 0, _value);
        }
    }
}