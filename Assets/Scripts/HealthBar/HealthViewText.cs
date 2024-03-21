using TMPro;
using UnityEngine;

public class HealthViewText : HealthUIElement
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start() => HealthChanged();

    protected override void HealthChanged()
    {
        int roundCurrentHealth = Mathf.RoundToInt(CurrentHealth);
        int roundMaxHealth = Mathf.RoundToInt(MaxHealth);

        _text.text = $"{roundCurrentHealth}/ {roundMaxHealth}";
    }
}
