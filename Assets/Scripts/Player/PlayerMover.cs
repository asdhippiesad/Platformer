using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);

    [SerializeField] int _speed;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _rotation;
    private Vector2 _move;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rotation = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        _move.x = Input.GetAxis(Horizontal);
        _rigidbody.velocity = new Vector2(_move.x * _speed, _rigidbody.velocity.y);
    }

    private void Flip() => _rotation.flipX = _move.x < 0;
}