using UnityEngine;

namespace Gameplay.Core.States
{
    public abstract class State : MonoBehaviour
    {
        protected StateType _type;
        protected IStateMachine _stateMachine;

        public StateType Type()
        {
            return _type;
        }

        public void SetType(StateType type)
        {
            _type = type;
        }

        public void OnAdd(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnRemove(IStateMachine stateMachine)
        {
            _stateMachine = null;
        }
        
        public abstract void OnEnter();
    
        public abstract void OnUpdate();

        public abstract void OnExit();
    }
}