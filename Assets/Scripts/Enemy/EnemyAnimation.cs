using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private float _speed = 1f;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Update() => SetRunAnimation();

    private void SetRunAnimation()
    {
        float runSpeed = Mathf.Abs(_speed);
        _animator.SetFloat(AnimatorData.Parameters.Run, Mathf.Abs(runSpeed));
    }
}
