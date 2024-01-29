using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _point;

    public event Action OnStartChasing;
    public event Action OnStopChasing;

    private Vector2 _move;
    private SpriteRenderer _rotation;

    private int _currentPosition;
    private float _thresholdDistance = 2f;
    private bool _shouldRight = true;
    private bool _isChasing = false;

    private void Awake() => _rotation = GetComponent<SpriteRenderer>();

    private void Update() => Move();

    public void StartChasing()
    {
        _isChasing = true;
        OnStartChasing?.Invoke();
    }

    public void StopChasing()
    {
        _isChasing = false;
        OnStopChasing?.Invoke();
    }

    public void Move()
    {

        transform.position = Vector3.MoveTowards(transform.position, _point[_currentPosition].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _point[_currentPosition].position) < _thresholdDistance)
        {
            _currentPosition = (_currentPosition + 1) % _point.Length;

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
