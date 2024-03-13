using TMPro;
using UnityEngine;

public class HealthViewText : HealthUIElement
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start() => HealthChanged();

    protected override void HealthChanged() => _text.text = $"{CurrentHealth}/ {MaxHealth}";
}
