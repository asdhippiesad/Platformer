using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

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
        _enemy.Attack();
    }
}
