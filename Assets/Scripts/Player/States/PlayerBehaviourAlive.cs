using UnityEngine;

public class PlayerBehaviourAlive : IBehaviour
{
    private PlayerMovement _movement;
    private PlayerRotation _rotator;

    public PlayerBehaviourAlive(PlayerMovement movement, PlayerRotation rotator)
    {
        _movement = movement;
        _rotator = rotator;
    }

    public void Enter()
    {
        _movement.enabled = true;
        _rotator.enabled = true;
    }

    public void Exit()
    {
        _movement.enabled = false;
        _rotator.enabled = false;
    }

    public void Update()
    {
        _movement.Move();
        _rotator.Rotate();
    }
}
