using Components;
using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "SpeedPotion", menuName = "Consumable/SpeedPotion", order = 53)]
    public class SpeedPotion : ScriptableObject
    {
        public GameObject Prefab;

        public SpeedBoostComponent SpeedBoost;
    }
}