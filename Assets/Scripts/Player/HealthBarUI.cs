using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    public Health fastHealth;
    public SlowHealthBar slowHealth;

    public void UpdateHealth(float maxhealth, float currenthealth)
    {
        fastHealth.UpdateHealth(maxhealth, currenthealth);
        slowHealth.UpdateHealth(maxhealth, currenthealth);
    }
}
