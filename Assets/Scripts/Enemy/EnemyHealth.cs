using UnityEngine;
using System;

[RequireComponent(typeof(EnemyAnimation))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    public static Action Attacked;

    private EnemyAnimation _enemyAnimation;
    private float _currentHealth;
    private float _minHealth = 0;

    private void Awake()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);
        Attacked?.Invoke();
        Die();
    }

    private void Die()
    {
        if (_currentHealth <= _minHealth)
            Destroy(gameObject);
    }
}
