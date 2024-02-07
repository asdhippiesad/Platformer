using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _damage = 40;
    [SerializeField] private int _attackRange = 10;
    [SerializeField] private LayerMask _playerLayer;

    private EnemyAnimation _enemyAnimation;
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnEnable() => _enemyHealth.Attacked += ReactToAttack;

    private void OnDisable() => _enemyHealth.Attacked -= ReactToAttack;

    public void ReactToAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _attackRange, _playerLayer);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == LayerMask.GetMask("Player"))
            {
                PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(_damage);
                    _enemyAnimation.Attack();
                    Debug.Log(_damage);
                }
            }
        }
    }
}