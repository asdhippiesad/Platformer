using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour
{
    private EnemyMovement _enemy;

    private void Awake() => _enemy = GetComponent<EnemyMovement>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _enemy.StartChasing(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _enemy.StopChasing();
        }
    }
}
