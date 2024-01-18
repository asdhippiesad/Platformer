using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimation : MonoBehaviour
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
        Move();
    }

    private void Move()
    {
        float runSpeed = Mathf.Abs(_rigidbody.velocity.x);
        _animator.SetFloat(AnimatorData.Parameters.Run, Mathf.Abs(runSpeed));
    }
}
