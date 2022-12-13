using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Background
{
    [RequireComponent(typeof(Movement))]
    public class MovementInputSystem : MonoBehaviour
    {
        private Movement _movement;

        private void Start()
        {
            _movement = gameObject.GetComponent<Movement>();
        }

        private void Update()
        {
            _movement.Input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        }
    }
}