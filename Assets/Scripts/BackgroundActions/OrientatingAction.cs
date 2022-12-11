using System;
using Components;
using UnityEngine;

namespace BackgroundActions
{
    public class OrientatingAction : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask groundLayerMask;
        
        private Movement _movement;
        private Transform _transform;

        private void Start()
        {
            _movement = gameObject.GetComponent<Movement>();
            _transform = transform;
        }

        private void Update()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var raycastHit, float.MaxValue, groundLayerMask))
            {
                // var eulerAngles = _transform.eulerAngles;
                // _transform.forward = (raycastHit.point - transform.position).normalized;
                // eulerAngles = _transform.eulerAngles - eulerAngles;
                // _movement.Velocity = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z) * _movement.Velocity;
                _transform.forward = (raycastHit.point - transform.position).normalized;
            }
        }
    }
}