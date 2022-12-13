using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Background
{
    [RequireComponent(typeof(Movement))]
    public class MovementSystem : MonoBehaviour
    {
        private Movement _movement;
        private Transform _transform;

        private void Start()
        {
            _movement = GetComponent<Movement>();
            _transform = transform;
        }

        private void Update()
        {
            _transform.position += _transform.forward * (_movement.Velocity.z * Time.deltaTime) +
                                   _transform.right * (_movement.Velocity.x * Time.deltaTime);
        }
    }
}