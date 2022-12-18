using UnityEngine;

namespace AI.Base
{
    public abstract class AGameObjectBasedAction : AAction
    {
        protected GameObject _gameObject;

        protected AGameObjectBasedAction(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
    }
}