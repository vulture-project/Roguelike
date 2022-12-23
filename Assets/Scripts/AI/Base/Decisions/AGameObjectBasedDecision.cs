using UnityEngine;

namespace AI.Base
{
    public abstract class AGameObjectBasedDecision : ADecision
    {
        protected GameObject _gameObject;

        protected AGameObjectBasedDecision(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
    }
}