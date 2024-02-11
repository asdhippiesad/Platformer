using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);

        if (_isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump() => _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
}
