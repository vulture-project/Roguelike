using UnityEngine;

namespace Gameplay.Core.States
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField]
        protected StateType _type;

        protected IStateSwitch _stateSwitch;

        public StateType Type()
        {
            return _type;
        }

        public void SetType(StateType type)
        {
            _type = type;
        }

        public void SetStateSwitch(IStateSwitch stateSwitch)
        {
            _stateSwitch = stateSwitch;
        }
        
        public void OnAdd(IStateSwitch stateSwitch)
        {
            _stateSwitch = stateSwitch;
        }

        public void OnRemove()
        {
            _stateSwitch = null;
        }
        
        public abstract void OnEnter();
    
        public abstract void OnUpdate();

        public abstract void OnExit();
    }
}