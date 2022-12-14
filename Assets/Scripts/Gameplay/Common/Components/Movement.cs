using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Common.Components
{
    [CreateAssetMenu(fileName = "MovementComponent", menuName = "Component/Movement", order = 52)]
    public class Movement : ScriptableObject, IComponent
    {
        public Vector3 Acceleration;
        
        public Vector3 Velocity;

        public Vector3 MaxVelocity;

        public Vector3 Input;
    }
}