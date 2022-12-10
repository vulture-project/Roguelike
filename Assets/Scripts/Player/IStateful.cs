namespace Player
{
    public interface IStateful
    {
        public void SwitchState(IState state);
    }
}