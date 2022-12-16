// using Leopotam.Ecs;
//
// using System;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.Assertions;
//
//     public class Singleton<T> : MonoBehaviour where T : class
//     {
//         private static T _instance;
//
//         public static T Instance()
//         {
//             return _instance;
//         }
//
//         private void Awake()
//         {
//             Assert.IsNull(_instance);
//             _instance = GetComponent<T>();
//         }
//     }
//
//     public class HealPotion : ScriptableObject
//     {
//         public GameObject Prefab;
//
//         public HealComponent Heal;
//     }
//     
//     public class HealPotionFactory : Singleton<HealPotionFactory>
//     {
//         [SerializeField]
//         private HealPotion _potion;
//
//         private EcsWorld _world;
//
//         public void Spawn(Vector3 position)
//         {
//             var potion = Instantiate(_potion, position, Quaternion.identity);
//             
//             
//         }
//
//         private void Start()
//         {
//             _world = GetComponent<World>().Get();
//         }
//     }
//
//     public class World : MonoBehaviour
//     {
//         private EcsWorld _world;
//
//         public EcsWorld Get()
//         {
//             return _world;
//         }
//     }
//     
//     [Serializable]
//     public struct HealComponent
//     {
//         public float Value;
//     }
//     
//     [Serializable]
//     public struct HealthComponent
//     {
//         public float Value;
//     }
//
//     [Serializable]
//     public struct MaxHealthComponent
//     {
//         public float Value;
//     }
//     
//     public struct CollisionComponent
//     {
//         public EcsEntity Entity;
//     }
//     
//     public class Entity : MonoBehaviour
//     {
//         private EcsEntity _entity;
//
//         public void Set(EcsEntity entity)
//         {
//             _entity = entity;
//         }
//         
//         public EcsEntity Get()
//         {
//             return _entity;
//         }
//     }
//
//     public class CollisionEventReceiver : MonoBehaviour
//     {
//         public void OnCollisionEnter(Collision collision)
//         {
//         }
//
//         public void OnCollisionExit(Collision collision)
//         {
//         }
//     }
