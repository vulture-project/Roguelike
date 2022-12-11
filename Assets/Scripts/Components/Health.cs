using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class Health : MonoBehaviour
    {
        public UnityEvent damaged;
        public UnityEvent healed;
        public UnityEvent killed;
        public UnityEvent recovered;

        [SerializeField] private float value;
        [SerializeField] private float maxValue;

        public float Value()
        {
            return value;
        }

        private void UpdateValue(float delta)
        {
            value = Mathf.Clamp(value + delta, 0, maxValue);
        }
        
        public void Damage(float damage)
        {
            UpdateValue(-damage);
            if (!Mathf.Approximately(value, 0f))
            {
                damaged.Invoke();
            }
            else
            {
                killed.Invoke();
            }
        }

        public void Heal(float heal)
        {
            UpdateValue(heal);
            if (!Mathf.Approximately(value, maxValue))
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