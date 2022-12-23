using UnityEngine;

namespace Components
{
    public struct SpeedBoostIconComponent
    {
        public SpeedBoostIconComponent(GameObject icon)
        {
            Icon = icon;
        }
        
        public GameObject Icon;
    }
}