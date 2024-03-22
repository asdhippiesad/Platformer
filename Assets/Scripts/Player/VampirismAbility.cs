using System.Collections;
using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private float _vampirismDuration = 6f;
    [SerializeField] private float _abilityRaduis = 10f;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Health _health;

    private Coroutine _coroutine;

    private float _drainRate = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            StartCoroutine(CastVampireAttack());
    }

    private IEnumerator CastVampireAttack()
    {
        float endTime = Time.time + _vampirismDuration;

        while (Time.time < endTime)
        {
            DrainHealth();
            yield return null;
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