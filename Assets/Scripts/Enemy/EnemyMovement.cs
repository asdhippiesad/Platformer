using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _point;

    public event Action OnStartChasing;
    public event Action OnStopChasing;

    public bool IsChasing = true;

    private Vector2 _move;
    private SpriteRenderer _rotation;
    private PlayerMover _player;
    private Vector3 _directionOfPlayer;

    private int _currentPosition;
    private float _thresholdDistance = 1f;
    private bool _shouldRight = true;
    private bool _patrolling = true;

    private void Awake()
    {
        _rotation = GetComponent<SpriteRenderer>();
    }

    private void Update() => Move();

    public void StartChasing(PlayerMover player)
    {
        _player = player;
        IsChasing = true;
        _patrolling = false;
        OnStartChasing?.Invoke();
    }

    public void StopChasing()
    {
        IsChasing = false;
        _patrolling = true;
        OnStopChasing?.Invoke();
    }

    public void Move()
    {
        if (_shouldRight)
        {
            MovePatrol();
        }
        else if (_player != null && IsChasing)
        {
            MoveChase();
        }
    }

    private void MovePatrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, _point[_currentPosition].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _point[_currentPosition].position) < _thresholdDistance)
        {
            _currentPosition = (_currentPosition + 1) % _point.Length;
            Flip();
        }
    }

    private void MoveChase()
    {
        if (_player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
            ChangingDirection();
        }
    }

    private void ChangingDirection()
    {
        if (_player.transform.position.x < transform.position.x && _shouldRight == false)
        {
            Flip();
        }
        else if(_player.transform.position.x > transform.position.x && _shouldRight == true)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _shouldRight = !_shouldRight;
        Transform sprite = transform;

        sprite.localScale = new Vector3(-sprite.localScale.x, sprite.localScale.y, sprite.localScale.z);
    }
}
