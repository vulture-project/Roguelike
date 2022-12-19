using Components;
using Core;
using Leopotam.Ecs;
using Prefabs;
using UnityComponents;
using UnityEngine;

namespace WeaponScripts
{
    public class SelfInitializedEntitySword : MonoBehaviour
    {
        [SerializeField] private SkeletonSword _skeletonSword;
        
        void Start()
        {
            var world = World.Instance().Get();
            
            var entity = world.NewEntity();
            entity.Replace(_skeletonSword.Damage);
            entity.Replace(new DamageSourceTag());

            GetComponent<Entity>().Set(entity);
        }
    }
}
