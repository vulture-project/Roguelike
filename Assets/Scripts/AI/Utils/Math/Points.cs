using UnityEngine;

namespace Utils.Math
{
    public static class Points
    {
        public static bool InOpenBall(Vector3 center, Vector3 toCheck, float sqrRadius)
        {
            return (center - toCheck).sqrMagnitude < sqrRadius;
        }

        public static bool CheckObjectRaycast(Ray ray, LayerMask mask)
        {
            return Physics.Raycast(ray, out var hit, float.MaxValue, mask);
        }
    }
}