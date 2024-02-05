using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _point;


    private Vector2 _move;
    private SpriteRenderer[] _rotation;
    private SpriteRenderer _spriteRenderer;
    private PlayerMover _player;

    private int _currentPosition;
    private float _thresholdDistance = 1f;
    private bool _isPatrolling = false;
    private bool _isChasing = true;

    private void Awake()
    {
        _rotation = GetComponentsInChildren<SpriteRenderer>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<PlayerMover>();
    }

    private void Update() => Move();

    public void StartChasing(PlayerMover player)
    {
        _player = player;
        _isChasing = true;
        _isPatrolling = false;
    }

    public void StopChasing()
    {
        _player = null;
        _isChasing = false;
        _isPatrolling = true;
        Flip(_spriteRenderer);
    }

    public void Move()
    {
        if (_player != null)
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
            Flip(_spriteRenderer);
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
            else
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