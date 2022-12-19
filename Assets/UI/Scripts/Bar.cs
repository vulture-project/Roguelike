using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Image healthBar;

    private Camera camera;

    void Awake()
    {
        camera = Camera.main;
    }

    public void SetHP(float percentage)
    {
        Debug.Log("Setting hp");
        healthBar.fillAmount = percentage;
    }

    void LateUpdate()
    {
        canvas.transform.LookAt(new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z));
        canvas.transform.Rotate(0, 180, 0);
    }
}
