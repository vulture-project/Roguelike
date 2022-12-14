using UnityEngine;

namespace Gameplay.Common.Behaviours
{
    public class Raycast : MonoBehaviour
    {
        [SerializeField]
        private Camera _mainCamera;

        [SerializeField]
        private LayerMask _groundLayerMask;

        public bool WithGround(out RaycastHit hit)
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, float.MaxValue, _groundLayerMask);
        }
    }
}