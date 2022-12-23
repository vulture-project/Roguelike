using UnityEngine;

namespace Components
{
    public struct GameObjectComponent
    {
        public readonly GameObject GameObject;

        public GameObjectComponent(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}