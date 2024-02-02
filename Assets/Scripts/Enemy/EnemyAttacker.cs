using UnityEngine;
using System;

public class EnemyAttacker : MonoBehaviour
{
    public event Action Attacked;

    private PlayerAttacker _player;

    private int _damage = 6;

    private void Awake() => _player = GetComponent<PlayerAttacker>();

    private void OnEnable() => Attacked += EnemyGiveAttack;

    private void OnDisable() => Attacked -= EnemyGiveAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {

        }
    }

    public void EnemyGiveAttack()
    {
        if (_player != null)
            _player.TakeDamage(_damage);
    }
}
