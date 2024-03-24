using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("Rotating properties")]
    [SerializeField] private float _speed;

    [Header("Visuals")] 
    [SerializeField] private Transform _visualsTransform;

    private Vector3 _lastRotation = Vector3.forward;

    private void Awake()
    {
        enabled = false;
    }

    public void Rotate()
    {
        _visualsTransform.rotation = Quaternion.RotateTowards(_visualsTransform.rotation, Quaternion.LookRotation(DetermineDirection()), _speed * Time.deltaTime);
    }

    private Vector3 DetermineDirection()
    {
        if (FireJoystickValues.Horizontal != 0 && FireJoystickValues.Vertical != 0)
        {
            _lastRotation = new Vector3(FireJoystickValues.Horizontal, 0f, FireJoystickValues.Vertical);
            return _lastRotation;
        }
        if (MovementJoystickValues.Horizontal != 0 && MovementJoystickValues.Vertical != 0)
        {
            _lastRotation = new Vector3(MovementJoystickValues.Horizontal, 0f, MovementJoystickValues.Vertical);
            return _lastRotation;
        }
        return _lastRotation;
    }
}
