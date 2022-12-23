using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Image healthBar;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void SetHP(float percentage)
    {
        healthBar.fillAmount = percentage;
    }

    private void LateUpdate()
    {
        var position = _camera.transform.position;
        canvas.transform.LookAt(new Vector3(position.x, position.y, position.z));
        canvas.transform.Rotate(0, 180, 0);
    }
}
