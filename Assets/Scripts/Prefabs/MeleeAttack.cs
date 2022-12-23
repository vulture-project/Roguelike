using Components;
using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "MeleeAttack", menuName = "Enemies/MeleeAttack", order = 51)]
    public class MeleeAttack : ScriptableObject
    {
        public DamageComponent Damage;
    }
}