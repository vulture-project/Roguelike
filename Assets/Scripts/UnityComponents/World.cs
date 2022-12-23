using Components;
using Factories;
using Leopotam.Ecs;
using MapGeneration;
using Systems;

namespace Core
{
    public class World : Singleton<World>
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _deferredSystems;

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
            _deferredSystems.Run();
        }

        private void OnDestroy()
        {
            _deferredSystems.Destroy();
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
                .Add(new AnimatingHitImpactSystem())
                .Add(new AnimatingDeathSystem())
                .Add(new AnimatingMovementForwardSystem())
                .Add(new AnimatingMovementSidewaysSystem())
                .Add(new ApplyDamageSystem())
                .Add(new ApplyHealSystem())
                .Add(new ApplyManaBoostSystem())
                .Add(new ApplySpeedBoostSystem())
                .Add(new DamageSystem())
                .Add(new DecelerationSystem())
                .Add(new DropSystem())
                .Add(new HealSystem())
                .Add(new HealthBarSystem())
                .Add(new HealthAndManaWizardSystem())
                .Add(new ManaBoostSystem())
                .Add(new SpeedBoostSystem())
                .Add(new SpeedBoostIconSystem())
                .Add(new MovementInputSystem())
                .Add(new MovementSystem())
                .Add(new NavMeshMovementSystem())
                .Add(new OrientationSystem())
                .Add(new SpellImpactSystem())
                .OneFrame<CollisionComponent>();

            _systems.Init();

            _deferredSystems = new EcsSystems(_world)
                .Add(new DestroySystem());
            
            _deferredSystems.Init();
        }

        private void InitFactories()
        {
            var healPotionFactory = GetComponent<HealPotionFactory>();
            healPotionFactory.Init();

            var manaPotionFactory = GetComponent<ManaPotionFactory>();
            manaPotionFactory.Init();
            
            var speedPotionFactory = GetComponent<SpeedPotionFactory>();
            speedPotionFactory.Init();

            var projectileFactory = GetComponent<ProjectileFactory>();
            projectileFactory.Init();

            var wizardFactory = GetComponent<WizardFactory>();
            wizardFactory.Init();
            
            var skeletonFactory = GetComponent<SkeletonFactory>();
            skeletonFactory.Init();
            
            var spiderFactory = GetComponent<SpiderFactory>();
            spiderFactory.Init();

            var orkFactory = GetComponent<OrkFactory>();
            orkFactory.Init();
            
            var lichFactory = GetComponent<LichFactory>();
            lichFactory.Init();
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