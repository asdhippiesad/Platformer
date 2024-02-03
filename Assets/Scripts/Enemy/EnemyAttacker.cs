using UnityEngine;
using System;

[RequireComponent(typeof(CapsuleCollider2D))]
public class EnemyAttacker : MonoBehaviour
{
    public event Action<int> Attacked;

    private int _damage = 6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CapsuleCollider2D>(out CapsuleCollider2D player))
        {
            Attacked?.Invoke(_damage);
            Debug.Log($"Enemy Attack - {_damage}");
        }
    }
}
