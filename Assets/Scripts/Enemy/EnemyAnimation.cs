using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetRunAnimation();
    }

    private void SetRunAnimation()
    {
        _animator.SetFloat("Run", 1);
    }
}
