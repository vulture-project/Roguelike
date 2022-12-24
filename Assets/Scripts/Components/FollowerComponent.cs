using Leopotam.Ecs;

using UnityEngine;

namespace Components
{
    public struct FollowerComponent
    {
        public EcsEntity Target;
        public Vector3 Offset;

        public FollowerComponent(EcsEntity target, Vector3 offset)
        {
            Target = target;
            Offset = offset;
        }
    }
}