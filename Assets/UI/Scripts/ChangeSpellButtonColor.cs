using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpellButtonColor : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    private Color lightColor = new Color(0.5f, 0.5f, 0.5f);
    private Color originalColor;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            image.color = lightColor;
        }
        else if (Input.GetKeyUp(key))
        {
            image.color = originalColor;
        }
    }
}