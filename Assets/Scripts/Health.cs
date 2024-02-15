using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 250;

    private float _currentHealth;
    private float _minHealth = 0;

    public bool IsAlive
    {
        get { return _currentHealth > _minHealth; }
    }

    private void Awake() => _currentHealth = _maxHealth;

    public void Heal(float amount)
    {
        float minHeal = 20;
        float maxHeal = 50;

        _currentHealth = Mathf.Clamp(_currentHealth + amount, minHeal, maxHeal);

        Debug.Log($"Heal Health - {_currentHealth}");
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Math.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);

        if (_currentHealth <= _minHealth)
            Destroy(gameObject);
    }
}
