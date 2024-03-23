using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _speed;

    [Header("Joystic")]
    [SerializeField] private Joystick _joystick;

    private float _horizontal => _joystick.Horizontal;
    private float _vertical => _joystick.Vertical;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector3(_horizontal, _transform.position.y, _vertical).normalized * _speed * Time.deltaTime);
    }
}
