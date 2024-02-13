using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    private float _currentHealth;
    private float _minHealth = 0;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            health.Heal(_currentHealth);
            Destroy(health.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Math.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);

        if (_currentHealth <= _minHealth)
            Destroy(gameObject);
    }
}
