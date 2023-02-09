using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.CompareTag("Enemy"))
        {
            if (Collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
            {
                enemyComponent.damage(1f);

            }

            Destroy(gameObject);
        }
    }
}
