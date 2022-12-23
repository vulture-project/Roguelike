using Components;
using Core;
using Leopotam.Ecs;
using Prefabs;
using UnityComponents;
using UnityEngine;

namespace WeaponScripts
{
    public class SelfInitializedMeleeAttackEntity : MonoBehaviour
    {
        [SerializeField] private MeleeAttack _meleeAttack;
        
        void Start()
        {
            var world = World.Instance().Get();
            
            var entity = world.NewEntity();
            entity.Replace(_meleeAttack.Damage);
            entity.Replace(new DamageSourceTag());

            GetComponent<Entity>().Set(entity);
        }
    }
}
