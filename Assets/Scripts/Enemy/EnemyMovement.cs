using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _point;

    private Coroutine _coroutine;
    private Vector2 _move;
    private SpriteRenderer _rotation;

    private int _currentPosition;
    private bool _shouldRight = true;
    private float _thresholdDistance = 0.2f;

    private void Awake()
    {
        _coroutine = StartCoroutine(Move());
        _rotation = GetComponent<SpriteRenderer>();
    }

    private IEnumerator Move()
    {
        while (enabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, _point[_currentPosition].position, _speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, _point[_currentPosition].position) < _thresholdDistance)
            {
                if (_currentPosition > 0)
                    _currentPosition = 0;
                else
                    _currentPosition = 1;

                Flip();
            }

            yield return null;
        }
    }

    private void Flip()
    {
        _shouldRight = !_shouldRight;
        Transform sprite = transform;

        sprite.localScale = new Vector3(-sprite.localScale.x, sprite.localScale.y, sprite.localScale.z);
    }
}
