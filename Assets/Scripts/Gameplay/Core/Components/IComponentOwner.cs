namespace Gameplay.Core.Components
{
    public interface IComponentOwner
    {
        public bool Has<TComponent>() where TComponent : ComponentBase;
        
        public TComponent Get<TComponent>() where TComponent : ComponentBase;

        public bool Add<TComponent>(TComponent component) where TComponent : ComponentBase;
        
        public bool Remove<TComponent>() where TComponent : ComponentBase;
    }
}