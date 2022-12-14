using UnityEngine;
using UnityEngine.AI;
using AI.Base;
using Utils.Math;
using System;
using AI.Common.Components;
using AI.Common.Events;

namespace AI.Common.Chase
{
    public class CatchToChaseDecision : ADecision
    {
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

        private readonly Catch _persecutorCatch;
        private readonly Transform _persecutorAgentTransform;
        private readonly Transform _targetTransform;

        private bool _needToComeCloser = false;
    }
}