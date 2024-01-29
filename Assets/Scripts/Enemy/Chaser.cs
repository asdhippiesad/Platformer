using UnityEngine;

public class Chaser : MonoBehaviour
{
    private EnemyMovement _enemy;

    private void Awake() =>_enemy = GetComponent<EnemyMovement>();

    private void OnEnable() => _enemy.OnStartChasing += OnStartChasing;

    private void OnDisable() => _enemy.OnStopChasing -= OnStopChasing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _enemy.StartChasing();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _enemy.StopChasing();
        }
    }

    private void OnStartChasing()
    {

    }

    private void OnStopChasing()
    {

    }
}
