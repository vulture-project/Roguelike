namespace Gameplay.Core.States
{
    public interface IStateSwitch
    {
        public void Switch(StateType type);

        public void Add(State state);

        public void Remove(State state);
    }
}