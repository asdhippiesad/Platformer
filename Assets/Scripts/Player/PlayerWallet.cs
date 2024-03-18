using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private float _coinCollected;

    private void Collected()
    {
        _coinCollected++;

        Debug.Log($"Coin - {_coinCollected}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CollectebleItem>(out CollectebleItem coin))
        {
            Collected();
            coin.Destroy();
        }
    }
}
