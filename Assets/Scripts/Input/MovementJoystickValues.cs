using UnityEngine;

public class MovementJoystickValues : MonoBehaviour
{
    private static Joystick _joystick;

    public static float Horizontal => _joystick != null ? _joystick.Horizontal : 0f;
    public static float Vertical => _joystick != null ? _joystick.Vertical : 0f;

    private void Awake()
    {
        if (_joystick == null)
        {
            _joystick = GetComponent<Joystick>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
