using UnityEngine;

public class VampirismController : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismAbility;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _vampirismAbility.ActiveVampirism();
            _playerAnimation.VampirismAttack();
        }
    }
}
