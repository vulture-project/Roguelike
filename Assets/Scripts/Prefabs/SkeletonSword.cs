using Components;
using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "SkeletonSword", menuName = "Enemies/SkeletonSword", order = 51)]
    public class SkeletonSword : ScriptableObject
    {
        public DamageComponent Damage;
    }
}