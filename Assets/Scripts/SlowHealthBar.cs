using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowHealthBar : MonoBehaviour
{
    private Image _image;
    private float _targetHealth;
    public float updateSpeed = 0.2f;
    
    void Start()
    {
        _image = GetComponent<Image>();
    }

    public void UpdateHealth(float maxhealth, float currenthealth)
    {
        _targetHealth = (float)currenthealth / maxhealth;
    }

    private void Update()
    {
        _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, _targetHealth, updateSpeed * Time.deltaTime);
    }
}