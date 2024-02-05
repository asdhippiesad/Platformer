using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float amount)
    {
        _currentHealth = amount;
        _currentHealth = Mathf.Min(amount, _currentHealth, _maxHealth);
    }
}
