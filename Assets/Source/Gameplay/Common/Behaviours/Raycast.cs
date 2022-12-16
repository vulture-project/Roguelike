using UnityEngine;

namespace Gameplay.Common.Behaviours
{
    public class Raycast : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _groundLayerMask;
        
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }
        
        public bool WithGround(out RaycastHit hit)
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, float.MaxValue, _groundLayerMask);
        }
    }
}