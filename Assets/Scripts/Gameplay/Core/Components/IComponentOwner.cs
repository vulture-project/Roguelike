namespace Gameplay.Core.Components
{
    public interface IComponentOwner
    {
        public bool Has<TComponent>() where TComponent : class, IComponent;
        
        public TComponent Get<TComponent>() where TComponent : class, IComponent;

        public bool Add<TComponent>(TComponent component) where TComponent : class, IComponent;
        
        public bool Remove<TComponent>() where TComponent : class, IComponent;
    }
}