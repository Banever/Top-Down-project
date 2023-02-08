using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigop : MonoBehaviour
{
    [SerializeField] float health, maxhealth = 3f;

    private void start()
    {
        maxhealth = health;
    }

    public void Takedamage(float damageamount)
    {
        health -= damageamount; 

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
