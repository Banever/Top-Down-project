using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Bullet;
    public Transform Bulletpos;
    public float _maxhealth = 6f;
    private float _currenthealth;
    private Health _healthbar;
    private float timer;

    void Start()
    {
        _currenthealth = _maxhealth;

        _healthbar = GetComponentInChildren<Health>();
    }

    void Update() 
    {
        HealthRegen();
;
        if(_currenthealth <= 0)
        {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            Shoot();
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

}