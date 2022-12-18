using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarWithoutRotation : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public void SetHP(float percentage)
    {
        healthBar.fillAmount = percentage;
    }
}
