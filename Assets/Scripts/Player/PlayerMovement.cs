using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _speed;

    private float _horizontal => MovementJoystickValues.Horizontal;
    private float _vertical => MovementJoystickValues.Vertical;

    private Transform _transform;

    private PlayerRotation _rotator;

    private void Awake()
    {
        _rotator = GetComponent<PlayerRotation>();
        _transform = transform;
        
    }

    public void Move()
    {
        Vector3 direction = new Vector3(_horizontal, _transform.position.y, _vertical).normalized;
        _transform.Translate(direction * _speed * Time.deltaTime);
        _rotator.RotateTo(direction);
    }
}
