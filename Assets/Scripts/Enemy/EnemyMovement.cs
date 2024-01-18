using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _point;
    [SerializeField] private int _currentPosition;

    private Coroutine _coroutine;
    private Vector2 _move;
    private SpriteRenderer _rotation;

    private float _waitForSecond = 2f;
    private bool _shouldRight = true;

    private void Awake()
    {
        _coroutine = StartCoroutine(Move(_waitForSecond));
        _rotation = GetComponent<SpriteRenderer>();
    }

    private IEnumerator Move(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, _point[_currentPosition].position, _speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, _point[_currentPosition].position) < 0.2f)
            {
                if (_currentPosition > 0)
                    _currentPosition = 0;
                else
                    _currentPosition = 1;

                Flip();

                yield return wait;
            }

            yield return null;
        }
    }

    private void Flip()
    {
        if ((_move.x > 0 && _shouldRight == false) || (_move.x < 0 && _shouldRight == true))
        {
            transform.localScale *= new Vector2(-1, 1);
            _shouldRight = _shouldRight = false;
        }
    }
}
