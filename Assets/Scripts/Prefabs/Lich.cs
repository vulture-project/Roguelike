using Components;

using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "Lich", menuName = "Enemies/Lich", order = 52)]
    public class Lich : ScriptableObject
    {
        public GameObject Prefab;

        public ArmourComponent Armour;
        public HealthComponent Health;
        public VelocityComponent Velocity;
    }
}