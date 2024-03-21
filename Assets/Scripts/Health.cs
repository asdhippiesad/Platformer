using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 250;

    private float _currentHealth;
    private float _healAmount = 50f;
    private PlayerAnimation _player;

    public event Action OnHealthChanged;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public bool IsAlive => _currentHealth > 0;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _player = GetComponent<PlayerAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CollectebleItem>(out CollectebleItem aidkit))
        {
            Heal(_healAmount);
            aidkit.Destroy();
        }
    }

    public void Heal(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0f, _maxHealth);
        OnHealthChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Math.Clamp(_currentHealth - damage, 0f, _maxHealth);
        OnHealthChanged?.Invoke();

        if (_currentHealth <= 0f)
            Destroy(gameObject);
    }
}
