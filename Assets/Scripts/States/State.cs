using UnityEngine;

namespace States
{
    public abstract class State : MonoBehaviour
    {
        public abstract void OnStart(IStateSwitch stateSwitch);
    
        public abstract void OnEnter();
    
        public abstract void OnUpdate();

        public abstract void OnExit();
    }
}