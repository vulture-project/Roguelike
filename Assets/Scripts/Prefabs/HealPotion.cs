using Components;

using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "HealPotion", menuName = "Consumable/HealPotion", order = 53)]
    public class HealPotion : ScriptableObject
    {
        public GameObject Prefab;

        public HealComponent Heal;
    }
}