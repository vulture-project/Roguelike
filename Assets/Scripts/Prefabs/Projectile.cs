using Components;
using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "Projectile", menuName = "Spell/Projectile", order = 54)]
    public class Projectile : ScriptableObject
    {
        public GameObject Prefab;
        public GameObject ImpactPrefab;

        public DamageComponent Damage;

        public VelocityComponent Velocity;

        public ManaComponent Mana;
    }
}