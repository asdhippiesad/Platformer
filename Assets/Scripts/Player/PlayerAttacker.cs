using UnityEngine;
using System;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackDistance = 0.45f;
    [SerializeField] private Transform _attackPoint;

    private EnemyAttacker _enemy;

    private int _damage = 50;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        Collider2D hitEnemy = Physics2D.OverlapCircle(_attackPoint.position, _attackDistance, _enemyLayer);

        if (hitEnemy != null)
        {
            _enemy.GetComponent<EnemyAttacker>().EnemyGiveAttack();
            Debug.Log($"Attack On: {_enemy} {damage}");
        }
    }


}
