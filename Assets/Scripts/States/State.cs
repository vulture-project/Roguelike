using UnityEngine;

namespace States
{
    public abstract class State : MonoBehaviour
    {
        protected IStateSwitch _stateSwitch;

        public void SetStateSwitch(IStateSwitch stateSwitch)
        {
            _stateSwitch = stateSwitch;
        }

        public abstract void OnEnter();

        public abstract void OnUpdate();

        public abstract void OnExit();
    }
}