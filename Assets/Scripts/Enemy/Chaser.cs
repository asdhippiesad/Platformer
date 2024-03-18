using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Chaser : MonoBehaviour
{
    private EnemyMovement _enemy;

    private void Awake() => _enemy = GetComponentInChildren<EnemyMovement>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
            _enemy.StartChasing(player);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
            _enemy.StopChasing();
    }
}
