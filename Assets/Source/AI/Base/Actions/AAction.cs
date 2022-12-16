namespace AI.Base
{
    public abstract class AAction
    {
        public virtual void OnEnter() {}
        public virtual void Execute() {}
        public virtual void OnExit() {}
    }
}