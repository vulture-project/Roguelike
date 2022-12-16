using UnityEngine;

namespace AI.Base
{
    public abstract class AGameObjectBasedAction : AAction
    {
        protected AGameObjectBasedAction(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        protected GameObject _gameObject;
    }
}