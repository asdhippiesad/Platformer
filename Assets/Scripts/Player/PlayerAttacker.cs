using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackDistance = 0.45f;
    [SerializeField] private Transform _attackPoint;

    private PlayerHealth _playerHealth;
    private float _damage = 50f;

    private void Awake() => _playerHealth = GetComponent<PlayerHealth>();

    private void OnEnable() => _playerHealth.Attacked += ReactToAttack;

    private void OnDisable() => _playerHealth.Attacked -= ReactToAttack;

    public void ReactToAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(_attackPoint.position, transform.right, _attackDistance, _enemyLayer);

        if (hit.collider != null)
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_damage);
                Debug.Log(_damage);
            }
        }
    }
}
