using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 250;

    public event Action OnHealthChanged;

    private float _currentHealth;
    private float _healAmount = 50f;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public bool IsAlive => _currentHealth > 0;

    private void Awake() => _currentHealth = _maxHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<AidKit>(out AidKit aidkit))
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

    public void TriggerHealthChanged() => OnHealthChanged?.Invoke();

}
