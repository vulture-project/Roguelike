using Leopotam.Ecs;
using UnityEngine;

namespace UnityComponents
{
    public class Entity : MonoBehaviour
    {
        private EcsEntity _entity;

        public EcsEntity Get()
        {
            return _entity;
        }

        public void Set(EcsEntity entity)
        {
            _entity = entity;
        }
    }
}