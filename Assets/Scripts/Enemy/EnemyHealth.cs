using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    public event Action Attacked;

    private PlayerAttacker _player;
    private float _currentHealth;
    private float _minHealth = 0;

    private void Awake() => _player = GetComponent<PlayerAttacker>();

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);
        _player.ReactToAttack();
        Debug.Log($"TakeDamage {damage}");
        Attacked?.Invoke();
    }
}
