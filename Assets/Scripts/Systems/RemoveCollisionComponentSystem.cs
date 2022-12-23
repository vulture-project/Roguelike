using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class RemoveCollisionComponentSystem : IEcsSystem
    {
        private EcsFilter<CollisionComponent>.Exclude<DestroyTag> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                entity.Del<CollisionComponent>();
            }
        }
    }
}