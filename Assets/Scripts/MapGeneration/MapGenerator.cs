using Core;
using Factories;
using UnityEngine;

namespace MapGeneration
{
    public class MapGenerator : Singleton<MapGenerator>
    {
        private HealPotionFactory _healPotionFactory;
        private ManaPotionFactory _manaPotionFactory;
        private WizardFactory _wizardFactory;
        private SkeletonFactory _skeletonFactory;
        
        // FIXME:
        [SerializeField] private GameObject _navMeshRoom;
        
        // FIXME:
        private GameObject _wizard;

        public void Init()
        {
            SetInstance(this);

            _healPotionFactory = HealPotionFactory.Instance();
            _manaPotionFactory = ManaPotionFactory.Instance();
            _wizardFactory = WizardFactory.Instance();
            _skeletonFactory = SkeletonFactory.Instance();
        }

        public void Generate()
        {
            _wizard = _wizardFactory.Spawn(Vector3.zero);
            _skeletonFactory.Spawn(new Vector3(-3f, 0f, 5f), _navMeshRoom, _wizard);

            _healPotionFactory.Spawn(new Vector3(2f, 0f, 2f));
            _manaPotionFactory.Spawn(new Vector3(-2f, 0f, 2f));
        }
    }
}