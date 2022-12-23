using Leopotam.Ecs;

namespace Components
{
    public struct CollisionComponent
    {
        public EcsEntity Target;

        public CollisionComponent(EcsEntity target)
        {
            Target = target;
        }
    }
}