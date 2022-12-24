using UnityEngine;

namespace Components
{
    public struct TransformComponent
    {
        public readonly Transform Transform;

        public TransformComponent(Transform transform)
        {
            Transform = transform;
        }
    }
}