using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D RigidBody;
    public float speed = 20f;
    
    void Start()
    {
        RigidBody.velocity = transform.forward * speed;
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.damage(1f);
            Destroy(gameObject);
        }     

    }
}
