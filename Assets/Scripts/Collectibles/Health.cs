using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMover>(out PlayerMover player))
            Destroy(gameObject);
    }
}
