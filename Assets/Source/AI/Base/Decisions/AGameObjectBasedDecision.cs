using UnityEngine;

namespace AI.Base
{
    public abstract class AGameObjectBasedDecision : ADecision
    {
        protected AGameObjectBasedDecision(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        protected GameObject _gameObject;
    }
}