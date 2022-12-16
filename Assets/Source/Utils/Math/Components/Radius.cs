using UnityEngine;

namespace Utils.Math.Components
{
    public class Radius : MonoBehaviour
    {
        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                SqrValue = value * value;
            }
        }

        public float SqrValue
        {
            get;
            private set;
        }

        private float _value;
    }
}
