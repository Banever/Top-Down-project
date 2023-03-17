using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PMOVE : MonoBehaviour
{
    public Rigidbody2D RB;
    public static PMOVE instance;
    public float vel = 5f;
    private Vector2 Movement;
    private Health _healthbar;
    public float _maxhealth = 6f;
    public float _currenthealth;
    private float timer;
    public int Keys;
    public event System.Action OnKeyAmountChanged;
    public bool cantmove = true;
    public bool autoheal;

    void Start()
    {
        _currenthealth = _maxhealth;

        _healthbar = GetComponentInChildren<Health>();
        Debug.Log("Sonido");
        AudioManager.Audio.Playsound();
    }

    private void Update()
    {
        HealthRegen();
        ProcessInputs();

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    [ContextMenu("Daño")]
    void DoDamage()
    {
        Damage(1);
    }

    public void HealItem(float healamount)
    {
        _currenthealth += healamount;
        _healthbar.UpdateHealth(_maxhealth, _currenthealth);
    }

    public void Damage(float damageamount)
    {
        _currenthealth -= damageamount;

        _healthbar.UpdateHealth(_maxhealth, _currenthealth);

        if (_currenthealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    void ProcessInputs()
    {
        float movex = Input.GetAxisRaw("Horizontal");

        float movey = Input.GetAxisRaw("Vertical");

       

        Movement = new Vector2(movex, movey);
    }

void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        RB.velocity = new Vector2(Movement.x * vel, Movement.y * vel);
    }

    public Transform Firepoint;
    public GameObject BulletPreFab;

    void Shoot()
    {
        Instantiate(BulletPreFab, Firepoint.position, Firepoint.rotation);
    }

    void HealthRegen()
    {

        if (!autoheal)       
            return;
        
        timer += Time.deltaTime;
        _healthbar.UpdateHealth(_maxhealth, _currenthealth);

        if (timer > 4)
        {
            timer = 0;
            _currenthealth += 1;
        }
        if(_currenthealth > _maxhealth)
        {
            _currenthealth = _maxhealth;
        }
    }

    public void IncreaseKeys()
    {
        Keys++;
        OnKeyAmountChanged?.Invoke();
    }

    public void DecreaseKeys()
    {
        Keys--;
        OnKeyAmountChanged?.Invoke();
    }

    public int GetKeyAmount() { return Keys; }

}
