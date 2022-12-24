using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class OrientationSystem : IEcsRunSystem
    {
        private EcsFilter<CameraComponent, LayerMaskComponent, TransformComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var camera = ref _filter.Get1(i);
                ref var layerMask = ref _filter.Get2(i);
                ref var transform = ref _filter.Get3(i);
                
                transform.Transform.RotateAround(transform.Transform.position, Vector3.up, 3f * Input.GetAxis("Mouse X"));
                
                // var ray = camera.MainCamera.ScreenPointToRay(Input.mousePosition);
                // if (Physics.Raycast(ray, out var hit, float.MaxValue, layerMask.GroundLayerMask))
                //     transform.Transform.forward = (hit.point - transform.Transform.position).normalized;
            }
        }
    }
}