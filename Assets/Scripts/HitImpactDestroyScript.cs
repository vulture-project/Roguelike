using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitImpactDestroyScript : MonoBehaviour
{
    [SerializeField] private float _duration = 3f;

    private float _durationLeft;

    private void Start()
    {
        _durationLeft = _duration;
    }

    void Update()
    {
        _durationLeft -= Time.deltaTime;

        if (_durationLeft <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
