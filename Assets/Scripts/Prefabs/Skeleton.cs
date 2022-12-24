using Components;
using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "Skeleton", menuName = "Enemies/Skeleton", order = 52)]
    public class Skeleton : ScriptableObject
    {
        public GameObject Prefab;

        public ArmourComponent Armour;
        public HealthComponent Health;
        public VelocityComponent Velocity;
    }
}