using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerAnimation _player;

    private float _speed = 3f;
    private float _attackDistance = 2f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<PlayerAnimation>();
    }

    private void Update()
    {
        Run();

        if (_player != null && Vector3.Distance(transform.position, _player.transform.position) <= _attackDistance)
            Attack();
    }

    public void Attack() => _animator.SetTrigger(AnimatorData.Parameters.Attack);

    private void Run() => _animator.SetFloat(AnimatorData.Parameters.Run, Mathf.Abs(_speed));

}
