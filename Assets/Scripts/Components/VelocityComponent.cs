using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct VelocityComponent
    {
        public Vector3 Value;
        public Vector3 MaxValue;
    }
}