using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
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
        transform.LookAt(new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
