using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    public event Action Attacked;

    private EnemyAttacker _enemy;
    private float _currentHealth;
    private float _minHealth = 0;

    private void Awake()
    {
        _enemy = GetComponent<EnemyAttacker>();
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
        _enemy.ReactToAttack();
        Attacked?.Invoke();
        Die();
    }

    private void Die()
    {
        if (_currentHealth <= _minHealth)
        {
            Destroy(gameObject);

        }
    }
}
