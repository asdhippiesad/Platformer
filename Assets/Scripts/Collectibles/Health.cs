using UnityEngine;

public class Health : MonoBehaviour
{
    private float healAmount = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            other.GetComponent<PlayerHealth>().Heal(healAmount);
            Debug.Log(healAmount);
            Destroy(gameObject);
        }
    }
}
