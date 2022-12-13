using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Background
{
    [RequireComponent(typeof(Movement))]
    public class AcceleratingSystem : MonoBehaviour
    {
        private Movement _movement;

        private void Start()
        {
            _movement = GetComponent<Movement>();
        }

        private void Update()
        {
            var deltaVelocity = _movement.Acceleration * Time.deltaTime;

            if (!Mathf.Approximately(_movement.Input.z, 0.0f))
            {
                var z = _movement.Velocity.z + _movement.Input.z * deltaVelocity.z;
                z = Mathf.Clamp(z, -_movement.MaxVelocity.z, _movement.MaxVelocity.z);
                _movement.Velocity += new Vector3(0f, 0f, z - _movement.Velocity.z);
            }
            else
            {
                if (0.05 <= _movement.Velocity.z || _movement.Velocity.z <= -0.05)
                {
                    _movement.Velocity -= new Vector3(0f, 0f, Mathf.Sign(_movement.Velocity.z) * deltaVelocity.z);
                }
                else
                {
                    _movement.Velocity = new Vector3(_movement.Velocity.x, 0f, 0f);
                }
            }

            if (!Mathf.Approximately(_movement.Input.x, 0.0f))
            {
                var x = _movement.Velocity.x + _movement.Input.x * deltaVelocity.x;
                x = Mathf.Clamp(x, -_movement.MaxVelocity.x, _movement.MaxVelocity.x);
                _movement.Velocity += new Vector3(x - _movement.Velocity.x, 0f, 0f);
            }
            else
            {
                if (0.05 <= _movement.Velocity.x || _movement.Velocity.x <= -0.05)
                {
                    _movement.Velocity -= new Vector3(Mathf.Sign(_movement.Velocity.x) * deltaVelocity.x, 0f, 0f);
                }
                else
                {
                    _movement.Velocity = new Vector3(0f, 0f, _movement.Velocity.z);
                }
            }
        }
    }
}
