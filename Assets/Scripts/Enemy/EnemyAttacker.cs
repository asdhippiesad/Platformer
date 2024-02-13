using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private int _attackRange = 1;
    [SerializeField] private Transform _attackPoint;

    private EnemyAnimation _enemyAnimation;
    private PlayerHealth _player;
    private float _damage = 15f;

    private void Awake()
    {
        _player = FindAnyObjectByType<PlayerHealth>();
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void OnEnable() => EnemyHealth.Attacked += Attack;

    private void OnDisable() => EnemyHealth.Attacked -= Attack;

    public void Attack()
    {
        _enemyAnimation.Attack();
        _player.TakeDamage(_damage);
    }
}