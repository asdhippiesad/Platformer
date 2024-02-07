using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health;

    public void Heal(float amount)
    {
        float minHeal = 20;
        float maxHeal = 50;

        _health = amount;
        _health = Mathf.Min(amount, minHeal, maxHeal);

        Debug.Log($"Heal Health - {_health}");
    }
}
