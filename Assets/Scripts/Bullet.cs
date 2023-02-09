using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float Speed = 20f;

    void Start()
    {
        Rigidbody.velocity = transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D Collision)
    { 
        if (Collision.gameObject.TryGetComponent<PMOVE>(out PMOVE playerComponent))
        {
            playerComponent.Damage(1f);
            Destroy(gameObject);
        }

    }
}
