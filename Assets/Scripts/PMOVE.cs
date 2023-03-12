using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMOVE : MonoBehaviour
{
    public Rigidbody2D RB;
    public float vel = 5f;
    private Vector2 Movement;
    private HealthBarUI _healthbar;
    public float _maxhealth = 6f;
    public float _currenthealth;
    private float timer;
    public bool healthRegen;
    public int keys;
    public event System.Action OnKeyAmountChanged;
    public bool canMove = true;

    void Start()
    {
        _currenthealth = _maxhealth;

        _healthbar = GetComponentInChildren<HealthBarUI>();
        UpdateHealthBar();
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
    [ContextMenu("Damage")]
    public void Damage()
    {
        Damage(1);
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

        if (!canMove)
        {
            movex = 0;
            movey = 0;
        }

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
        if (!healthRegen)
            return;

        timer += Time.deltaTime;

        if (timer > 4)
        {
            timer = 0;
            _currenthealth += 1;
            if (_currenthealth > _maxhealth)
                _currenthealth = _maxhealth;
            UpdateHealthBar();
        }
    }

    [ContextMenu("Update Health Bar")]
    private void UpdateHealthBar()
    {
        //_healthbar.UpdateHealth(_maxhealth, _currenthealth);
    }

    public void IncreaseKeys()
    {
        keys++;
        OnKeyAmountChanged?.Invoke();
    }

    public void DecreaseKeys() 
    {
        keys--;
        OnKeyAmountChanged?.Invoke();
    }

    public int GetKeyAmount () { return keys; }

    public override string ToString()
    {
        return "asdfgsdghsdfgh";
    }

    public void SetPlayerMovementState(bool state)
    {
        canMove = state;
    }

}
