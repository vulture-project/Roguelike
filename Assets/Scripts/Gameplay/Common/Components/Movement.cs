using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Common.Components
{
    [CreateAssetMenu(fileName = "Movement", menuName = "Component/Movement", order = 52)]
    public class Movement : ComponentBase
    {
        public Vector3 Acceleration;
        
        public Vector3 Velocity;

        public Vector3 MaxVelocity;

        public Vector3 Input;
    }
}