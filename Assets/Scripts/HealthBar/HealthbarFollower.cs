using UnityEngine;

public class HealthbarFollower : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemy;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        if (_enemy != null)
            transform.position = _enemy.transform.position + _offset;
        else
            Destroy(gameObject);
    }
}
