using UnityEngine;
using System;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackDistance = 0.45f;
    [SerializeField] private Transform _attackPoint;

    public event Action<int> OnAttack;

    private int _damage = 50;

    private void Update() => Attack(_damage);

    public void Attack(int damage)
    {
        Collider2D hitEnemy = Physics2D.OverlapCircle(_attackPoint.position, _attackDistance, _enemyLayer);

        if (hitEnemy != null)
        {
            OnAttack?.Invoke(damage);
            Debug.Log("Attack");
        }
    }
}
