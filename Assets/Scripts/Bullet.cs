using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Collision)
    { 
        if (Collision.gameObject.TryGetComponent<PMOVE>(out PMOVE playerComponent))
        {
            playerComponent.Damage(1f);
        }

        Destroy(gameObject);

    }
}
