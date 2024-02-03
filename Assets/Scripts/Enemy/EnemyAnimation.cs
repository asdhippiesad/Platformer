using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private float _speed = 1f;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Update()
    {
        Run();
        Attack();
    }

    private void Attack() => _animator.SetTrigger(AnimatorData.Parameters.Attack);

    private void Run() => _animator.SetFloat(AnimatorData.Parameters.Run, Mathf.Abs(_speed));
}
