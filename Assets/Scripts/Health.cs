using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 250;

    public event Action OnHealthChanged;
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private float _currentHealth;

    public bool IsAlive
    {
        get { return _currentHealth > 0; }
    }

    private void Awake() => _currentHealth = _maxHealth;

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
