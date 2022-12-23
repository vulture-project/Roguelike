using Components;
using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "Spider", menuName = "Enemies/Spider", order = 51)]
    public class Spider : ScriptableObject
    {
        public GameObject Prefab;

        public ArmourComponent Armour;
        public HealthComponent Health;
        public VelocityComponent Velocity;
    }
}