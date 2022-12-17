using Core;
using Factories;

using UnityEngine;

namespace MapGeneration
{
    public class MapGenerator : Singleton<MapGenerator>
    {
        private HealPotionFactory _healPotionFactory;
        private WizardFactory _wizardFactory;

        public void Init()
        {
            SetInstance(this);

            _healPotionFactory = HealPotionFactory.Instance();
            _wizardFactory = WizardFactory.Instance();
        }
        
        public void Generate()
        {
            _wizardFactory.Spawn(Vector3.zero);
            
            _healPotionFactory.Spawn(new Vector3(2f, 0f, 2f));            
        }
    }
}