using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _point;

    private Vector2 _move;
    private PlayerMover _player;

    private int _currentPosition;
    private float _thresholdDistance = 1f;
    private bool _isChasing = true;
    private bool _isShouldRight = true;

    private void Awake() => _player = GetComponent<PlayerMover>();

    private void Update()
    {
        if (_isChasing && _player != null)
            MoveChase();
        else
            MovePatrol();
    }

    public void StartChasing(PlayerMover player)
    {
        _player = player;
        _isChasing = true;
    }

    public void StopChasing()
    {
        _player = null;
        _isChasing = false;
        Flip();
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
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        else
            ChangingDirection();
    }

    private void ChangingDirection()
    {
        if (transform.position.x < _player.transform.position.x && _isShouldRight == true)
            Flip();
        else if (transform.position.x > _player.transform.position.x && _isShouldRight == false)
            Flip();
    }

    private void Flip()
    {
        _isShouldRight = !_isShouldRight;
        Transform sprite = transform;
        sprite.localScale = new Vector3(-sprite.localScale.x, sprite.localScale.y, sprite.localScale.z);
    }
}