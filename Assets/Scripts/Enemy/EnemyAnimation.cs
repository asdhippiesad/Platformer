using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private float _speed = 3f;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Update() => Run();

    public void Attack() => _animator.SetTrigger(AnimatorData.Parameters.Attack);

    public void Dead() => _animator.SetTrigger(AnimatorData.Parameters.Run);

    private void Run() => _animator.SetFloat(AnimatorData.Parameters.Run, Mathf.Abs(_speed));

}
