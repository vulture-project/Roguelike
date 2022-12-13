using UnityEngine;

namespace Gameplay.Core.Components
{
    public class Movement : MonoBehaviour
    {
        public Vector3 Acceleration { get; private set; }
        
        public Vector3 Velocity { get; set; }
        
        public Vector3 MaxVelocity { get; private set; }
        
        public Vector3 Input { get; set; }

        private void Start()
        {
            Acceleration = new Vector3(1f, 0f, 1f);
            Velocity = new Vector3(0f, 0f, 0f);
            MaxVelocity = new Vector3(1f, 0f, 1f);
            Input = new Vector3(0f, 0f, 0f);
        }
    }
}