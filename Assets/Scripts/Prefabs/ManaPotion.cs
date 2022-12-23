using Components;
using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "ManaPotion", menuName = "Consumable/ManaPotion", order = 53)]
    public class ManaPotion : ScriptableObject
    {
        public GameObject Prefab;

        public ManaBoostComponent ManaBoost;
    }
}