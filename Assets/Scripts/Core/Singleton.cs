using UnityEngine;
using UnityEngine.Assertions;

namespace Core
{
     public class Singleton<T> : MonoBehaviour where T : class
     {
         private static T _instance;

         public static T Instance()
         {
             Assert.IsNotNull(_instance, typeof(T).ToString());
             return _instance;
         }
         
         protected void SetInstance(T instance)
         {
             _instance = instance;
         }
     }
}