using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepoint : MonoBehaviour
{
    public Transform firepoint;
    public GameObject BulletPreFab;
    float Timebetweenshots;
    public float startingtimebetweenshots;

    void start()
    {
        Timebetweenshots = startingtimebetweenshots;
    }

    void update()
    {
        if (Timebetweenshots <= 0)
        {
            Instantiate(BulletPreFab, firepoint.position, firepoint.rotation);
              Timebetweenshots = startingtimebetweenshots;
        }

        else
        {
            Timebetweenshots -= Time.deltaTime;
        }

    }
    
}
