using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.TryGetComponent<PMOVE>(out PMOVE playerComponent))
        {
            playerComponent.HealItem(2f);
            Destroy(gameObject);
        }
    }
 
}
