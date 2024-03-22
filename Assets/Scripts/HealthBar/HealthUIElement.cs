using UnityEngine;

public abstract class HealthUIElement : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected float MaxHealth => _health.MaxHealth;

    protected float CurrentHealth => _health.CurrentHealth;

    private void Awake() => _health.HealthChanged += HealthChanged;

    private void OnDisable() => _health.HealthChanged -= HealthChanged;

    protected abstract void HealthChanged();
}
