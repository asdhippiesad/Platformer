using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _damage = 40;
    [SerializeField] private int _attackRange = 1;

    private EnemyAnimation _enemyAnimation;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void OnEnable()
    {
        if (_playerHealth != null)
            _playerHealth.Attacked += ReactToAttack;
    }

    private void OnDisable()
    {
        if (_playerHealth != null)
            _playerHealth.Attacked -= ReactToAttack;
    }

    public void ReactToAttack()
    {
        if (Vector3.Distance(transform.position, _playerHealth.transform.position) <= _attackRange)
        {
            _enemyAnimation.Attack();
            _playerHealth.TakeDamage(_damage);
        }
    }
}