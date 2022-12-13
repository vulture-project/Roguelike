namespace Gameplay.Core.States
{
    public interface IStateMachine
    {
        public void Switch(StateType type);

        public void SetType(State state, StateType type);

        public void AddState(State state);

        public void RemoveState(State state);
    }
}