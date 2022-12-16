using Core;

using Leopotam.Ecs;

namespace UnityComponents
{
    public class World : Singleton<World>
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        
        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
        }

        private void Update()
        {
            _systems.Run();
        }
    }
}