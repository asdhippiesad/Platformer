using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _attackDistance = 1;
    [SerializeField]private Transform _attackPoint;

    private EnemyHealth _enemyHealth;
    private float _damage = 50f;

    private void Awake() => _enemyHealth = GetComponent<EnemyHealth>();

    private void OnEnable()
    {
        if (_enemyHealth != null)
            _enemyHealth.Attacked += ReactToAttack;
    }

    private void OnDisable()
    {
        if (_enemyHealth != null)
            _enemyHealth.Attacked -= ReactToAttack;
    }

    public void ReactToAttack()
    {
        if (Vector3.Distance(transform.position, _enemyHealth.transform.position) <= _attackDistance)
        {
            _enemyHealth.TakeDamage(_damage);
            Debug.Log($"{_damage} - Attack.");
        }
    }
}
