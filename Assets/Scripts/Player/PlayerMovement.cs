using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _speed;

    [Header("Joystick")]
    [SerializeField] private Joystick _joystick;

    private float _horizontal => _joystick.Horizontal;
    private float _vertical => _joystick.Vertical;

    private Transform _transform;

    private PlayerRotation _rotator;

    private void Awake()
    {
        _rotator = GetComponent<PlayerRotation>();
        _transform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_horizontal, _transform.position.y, _vertical).normalized;
        _transform.Translate(direction * _speed * Time.deltaTime);
        _rotator.RotateTo(direction);
    }
}
