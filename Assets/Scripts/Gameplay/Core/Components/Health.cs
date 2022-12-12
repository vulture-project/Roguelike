using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Core.Components
{
    public class Health : MonoBehaviour
    {
        public UnityEvent damaged;
        public UnityEvent healed;
        public UnityEvent killed;
        public UnityEvent recovered;

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
            _value = Mathf.Clamp(_value - value, 0, _maxValue);
            if (!Mathf.Approximately(value, 0f))
            {
                damaged.Invoke();
            }
            else
            {
                killed.Invoke();
            }
        }

        public void Heal(float value)
        {
            _value = Mathf.Clamp(_value + value, 0, _maxValue);;
            if (!Mathf.Approximately(value, _maxValue))
            {
                healed.Invoke();
            }
            else
            {
                recovered.Invoke();
            }
        }
    }
}