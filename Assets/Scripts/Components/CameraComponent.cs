using UnityEngine;

namespace Components
{
    public struct CameraComponent
    {
        public readonly Camera MainCamera;

        public CameraComponent(Camera camera)
        {
            MainCamera = camera;
        }
    }
}