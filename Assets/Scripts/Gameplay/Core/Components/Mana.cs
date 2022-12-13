using UnityEngine;

namespace  Gameplay.Core.Components
{
    public class Mana : MonoBehaviour
    {
        [SerializeField]
        private float _value;

        [SerializeField]
        private float _maxValue;

        public float Value()
        {
            return _value;
        }

        public void Spend(float value)
        {
            _value = Mathf.Clamp(_value - value, 0, _maxValue);
        }

        public void Recover(float value)
        {
            _value = Mathf.Clamp(_value + value, 0, _maxValue);
        }
    }
}