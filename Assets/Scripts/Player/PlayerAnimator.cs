using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerJump()
    {
        _animator.SetBool(AnimatorData.Parameters.Jump, true);
    }

    private void PlayerMove()
    {
        float runSpeed = Mathf.Abs(_rigidbody.velocity.x);
        _animator.SetFloat(AnimatorData.Parameters.Run, Mathf.Abs(runSpeed));
    }
}
