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

    public void ActiveVampirism() => StartCoroutine(CastVampireAttack());

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
            if (enemy.TryGetComponent(out Health health) && enemy.TryGetComponent(out Attacker attack) && enemy.gameObject != gameObject)
            {
                float damage = _drainRate * Time.deltaTime;

                if (enemy != null)
                    health.TakeDamage(damage);

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