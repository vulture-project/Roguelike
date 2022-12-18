using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace UnityComponents
{
    [RequireComponent(typeof(Entity))]
    public class CollisionEventReceiver : MonoBehaviour
    {
        private Entity _entity;

        private void Start()
        {
            _entity = GetComponent<Entity>();
        }

        private void OnTriggerEnter(Collider collision)
        {
            var entity = collision.gameObject.GetComponent<Entity>();
            if (entity != null) _entity.Get().Replace(new CollisionComponent(entity.Get()));
        }

        private void OnTriggerExit(Collider collision)
        {
            _entity.Get().Del<CollisionComponent>();
        }
    }
}