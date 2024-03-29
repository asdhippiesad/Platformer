using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackDistance = 1;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackCoolDown = 0.2f;
    [SerializeField] private float _damage;

    private float _nextAttackTime = 0f;

    private void Update()
    {
        if (Time.time >= _nextAttackTime)
        {
            Attack();
        }
    }

    public void Attack()
    {
        _nextAttackTime = Time.time + _attackCoolDown;

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(_attackPoint.position, _attackDistance, _enemyLayer);

        foreach (var enemyCollider in hitEnemy)
        {
            if (enemyCollider.TryGetComponent(out Health health))
                health.TakeDamage(_damage);
        }
    }
}