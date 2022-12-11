using Components;
using UnityEngine;

namespace BackgroundActions
{
    public class InputHandlingAction : MonoBehaviour
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