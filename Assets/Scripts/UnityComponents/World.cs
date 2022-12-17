using Core;
using Factories;
using MapGeneration;
using Systems;

using Leopotam.Ecs;

namespace Core
{
    public class World : Singleton<World>
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        public EcsWorld Get()
        {
            return _world;
        }
        
        private void Start()
        {
            SetInstance(this);
            InitEcs();
            InitFactories();
            InitMapGenerator();
            GenerateMap();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }

        private void InitEcs()
        {
            _world = new EcsWorld();

            _systems = new EcsSystems(_world)
                .Add(new AccelerationSystem())
                .Add(new AnimatingMovementSystem())
                .Add(new ApplyDamageSystem())
                .Add(new ApplyHealSystem())
                .Add(new DamageSystem())
                .Add(new DecelerationSystem())
                .Add(new DestroySystem())
                .Add(new HealSystem())
                .Add(new MovementInputSystem())
                .Add(new MovementSystem())
                .Add(new OrientationSystem());

            _systems.Init();
        }
        
        private void InitFactories()
        {
            var healPotionFactory = GetComponent<HealPotionFactory>();
            healPotionFactory.Init();

            var projectileFactory = GetComponent<ProjectileFactory>();
            projectileFactory.Init();
            
            var wizardFactory = GetComponent<WizardFactory>();
            wizardFactory.Init();
        }

        private void InitMapGenerator()
        {
            var mapGenerator = GetComponent<MapGenerator>();
            mapGenerator.Init();
        }

        private void GenerateMap()
        {
            var mapGenerator = GetComponent<MapGenerator>();
            mapGenerator.Generate();
        }
    }
}