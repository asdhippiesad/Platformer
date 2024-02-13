using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackDistance = 1;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackCoolDown = 0.2f;

    private float _damage = 14f;
    private float _lastAttackTime;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _lastAttackTime + _attackCoolDown)
        {
            Attack();
            _lastAttackTime = Time.time;
        }
    }

    public void Attack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(_attackPoint.position, _attackDistance, _enemyLayer);

        foreach (var enemyCollider in hitEnemy)
        {
            EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_damage);
            }
        }
    }
}
