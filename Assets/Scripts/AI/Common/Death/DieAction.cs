using AI.Base;
using Components;
using Leopotam.Ecs;
using UnityComponents;

using UnityEngine;

namespace AI.Common.Death
{
    public class DieAction : AGameObjectBasedAction
    {
        private readonly Entity _entity; 
        
        public DieAction(GameObject gameObject) : base(gameObject)
        {
            _entity = _gameObject.GetComponent<Entity>();
        }
        
        public override void OnEnter()
        {
            _entity.Get().Replace(new DestroyTag());
        }
    }
}