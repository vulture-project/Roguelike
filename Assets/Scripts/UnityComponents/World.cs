using Factories;
using Leopotam.Ecs;
using MapGeneration;
using Systems;

namespace Core
{
    public class World : Singleton<World>
    {
        private EcsSystems _systems;
        private EcsWorld _world;

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

        public EcsWorld Get()
        {
            return _world;
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

            var manaPotionFactory = GetComponent<ManaPotionFactory>();
            manaPotionFactory.Init();

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