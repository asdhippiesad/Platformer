using System.Collections;
using UnityEngine;
using static Health;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private float _coolDown = 10f;
    [SerializeField] private float _vampirismDuration = 6f;
    [SerializeField] private float _abilityRaduis = 3f;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Attacker _playerAttack;
    [SerializeField] private Health _health;

    private Coroutine _coroutine;

    private float _drainRate = 1f;
    private bool _isAttacking = true;
    private float _nextCoolDownAttack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _isAttacking && Time.time >= _nextCoolDownAttack)
            StartCoroutine(CastVampireAttack());
    }

    private IEnumerator CastVampireAttack()
    {
        _nextCoolDownAttack = Time.time + _coolDown;

        var attackTime = _vampirismDuration;

        float timer = 0f;

        while (timer < _vampirismDuration)
        {
            DrainHealth();
            timer += Time.deltaTime;
            yield return attackTime;
        }
    }

    private void DrainHealth()
    {
        Collider2D[] hitEnemeies = Physics2D.OverlapCircleAll(transform.position, _abilityRaduis, _enemyLayer);

        foreach (Collider2D enemy in hitEnemeies)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            Attacker enemyAttacker = enemy.GetComponent<Attacker>();

            if (enemyHealth != null && enemyAttacker != null && enemy.gameObject != gameObject)
            {
                float damage = _drainRate * Time.deltaTime;

                enemyHealth.TakeDamage(damage);
                _health.Heal(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _abilityRaduis);
    }
}