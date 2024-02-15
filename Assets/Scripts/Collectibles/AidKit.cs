using UnityEngine;

public class AidKit : MonoBehaviour
{
    private float _healAmount = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            Health playerHealth = collision.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.Heal(_healAmount);
                Destroy(gameObject);
            }
        }
    }
}
