using System;
using AI.Base;
using AI.Common.Components;
using AI.Common.Events;
using UnityEngine;
using UnityEngine.AI;
using Utils.Math;

namespace AI.Common.Chase
{
    public class CatchToChaseDecision : ADecision
    {
        private readonly Transform _persecutorAgentTransform;

        private readonly Catch _persecutorCatch;
        private readonly Transform _targetTransform;

        private bool _needToComeCloser;

        public CatchToChaseDecision(GameObject persecutor, GameObject target,
            MovementNotifier movementNotifier)
        {
            _persecutorCatch = persecutor.GetComponent<Catch>();
            _persecutorAgentTransform = persecutor.GetComponent<NavMeshAgent>().transform;
            _targetTransform = target.transform;
            movementNotifier.NeedToComeCloser += OnNeedToComeCloser;
        }

        public override bool Decide()
        {
            var result = !Points.InOpenBall(_targetTransform.position,
                             _persecutorAgentTransform.position,
                             _persecutorCatch.SqrValue) ||
                         _needToComeCloser;
            _needToComeCloser = false;
            return result;
        }

        public void OnNeedToComeCloser(object sender, EventArgs args)
        {
            _needToComeCloser = true;
        }
    }
}