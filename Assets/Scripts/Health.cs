using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Image _image;
    
    void Start()
    {
        _image = GetComponent<Image>();

    }

    public void UpdateHealth(float maxhealth, float currenthealth)
    {
        _image.fillAmount = currenthealth / maxhealth;
    }
}