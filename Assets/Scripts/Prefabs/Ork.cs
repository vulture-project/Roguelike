using Components;
using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "Ork", menuName = "Enemies/Ork", order = 52)]
    public class Ork : ScriptableObject
    {
        public GameObject Prefab;

        public ArmourComponent Armour;
        public HealthComponent Health;
        public VelocityComponent Velocity;
    }
}