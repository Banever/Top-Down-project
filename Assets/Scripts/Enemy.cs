using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Bullet;
    public Transform Bulletpos;
    public float _maxhealth = 6f;
    private float _currenthealth;
    private Health _healthbar;
    private float timer;
    public Transform RayStart;
    private Rigidbody2D Rigidbody;
    private float Speed = 10f;


    void Start()
    {
        _currenthealth = _maxhealth;

        _healthbar = GetComponentInChildren<Health>();

        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.velocity = transform.right * Speed;
    }

    void Update()
    {
        HealthRegen();
        ;
        if (_currenthealth <= 0)
        {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(RayStart.position, Vector2.right);
        if (!hit.collider.CompareTag("Player"))
        {
            return;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        Instantiate(Bullet, Bulletpos.position, Quaternion.identity);
    }

    public void damage(float damageamount)
    {
        _currenthealth -= damageamount;

        _healthbar.UpdateHealth(_maxhealth, _currenthealth);

        if(_currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void HealthRegen()
    {
        timer += Time.deltaTime;
        _healthbar.UpdateHealth(_maxhealth, _currenthealth);

        if (timer > 4)
        {
            timer = 0;
            _currenthealth += 1;
        }
        if (_currenthealth > _maxhealth)
        {
            _currenthealth = _maxhealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.CompareTag("Wall"))
            transform.position = new Vector2(-8, 0);        
    }

}