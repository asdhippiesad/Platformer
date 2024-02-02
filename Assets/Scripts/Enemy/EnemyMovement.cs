using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _point;

    public bool IsChasing = true;

    private Vector2 _move;
    private SpriteRenderer[] _rotation;
    private PlayerMover _player;
    private Vector3 _directionOfPlayer;

    private int _currentPosition;
    private float _thresholdDistance = 1f;
    private bool _shouldRight = true;
    private bool _patrolling = false;

    private void Awake()
    {
        _rotation = GetComponentsInChildren<SpriteRenderer>();
        _player = GetComponent<PlayerMover>();
    }

    private void Update() => Move();

    public void StartChasing(PlayerMover player)
    {
        _player = player;
        IsChasing = true;
        _patrolling = false;
    }

    public void StopChasing()
    {
        IsChasing = false;
        _patrolling = true;
    }

    public void Move()
    {
        if (_player != null && IsChasing)
        {
            MoveChase();
        }
        else
        {
            MovePatrol();
        }
    }

    private void MovePatrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, _point[_currentPosition].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _point[_currentPosition].position) < _thresholdDistance)
        {
            _currentPosition = (_currentPosition + 1) % _point.Length;
            ChangingDirection();
        }
    }

    private void MoveChase()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        ChangingDirection();
    }

    private void ChangingDirection()
    {
        foreach (SpriteRenderer spriteRenderer in _rotation)
        {
            if (_player != null)
            {
                if (transform.position.x < _player.transform.position.x && spriteRenderer.flipX == false)
                {
                    Flip(spriteRenderer);
                }
                else if (transform.position.x > _player.transform.position.x && spriteRenderer.flipX == true)
                {
                    Flip(spriteRenderer);
                }
            }
            else if (_player == null)
            {
                Flip(spriteRenderer);
            }
        }
    }

    private void Flip(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
