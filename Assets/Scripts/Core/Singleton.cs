using UnityEngine;
using UnityEngine.Assertions;

namespace Core
{
     public class Singleton<T> : MonoBehaviour where T : class
     {
         private static T _instance;

         public static T Instance()
         {
             return _instance;
         }

         private void Awake()
         {
             Assert.IsNull(_instance);
             _instance = GetComponent<T>();
         }
     }
}