using Components;
using UnityEngine;

namespace BackgroundActions
{
    public class MovementAction : MonoBehaviour
    {
        private Movement _movement;
        private Transform _transform;

        private void Start()
        {
            _movement = gameObject.GetComponent<Movement>();
            _transform = transform;
        }

        private void Update()
        {
            _transform.position += _transform.forward * (_movement.Velocity.z * Time.deltaTime) +
                                   _transform.right * (_movement.Velocity.x * Time.deltaTime);
        }
    }
}