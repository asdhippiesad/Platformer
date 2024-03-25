using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerTarget;

    private void LateUpdate()
    {
        var position = transform.position;
        position.x = _playerTarget.transform.position.x;
        transform.position = position;
    }
}
