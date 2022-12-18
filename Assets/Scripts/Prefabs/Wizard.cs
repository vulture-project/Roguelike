using Components;
using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "Wizard", menuName = "Hero/Wizard", order = 51)]
    public class Wizard : ScriptableObject
    {
        public GameObject Prefab;

        public AccelerationComponent Acceleration;

        public ArmourComponent Armour;

        public HealthComponent Health;

        public LayerMaskComponent LayerMask;

        public VelocityComponent Velocity;
    }
}