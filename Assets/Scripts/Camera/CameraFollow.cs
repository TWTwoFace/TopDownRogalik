using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Following trandform")]
    [SerializeField] private Transform _followingTarget;

    [Space, Header("Offset border")]
    [SerializeField] private float _borderSize;

    [Space, Header("Camera's properties")]
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private MoveType _moveType;

    private Transform _transform;

    private delegate void MoveDelegate();

    MoveDelegate Move;

    private enum MoveType
    {
        Interpolated,
        Towards
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        DetermineMovementMethod();
    }

    private float GetDistanceToTarget()
    {
        float distance = new Vector3(_transform.position.x - _followingTarget.position.x, 0f, _transform.position.z - _followingTarget.position.z).magnitude;
        return distance;
    }

    private void Update()
    {
        if (HasTargetMowedAway())
        {
            Move();
        }
    }

    private bool HasTargetMowedAway()
    {
        return GetDistanceToTarget() > _borderSize;
    }

    private Vector3 GetTargetPosition()
    {
        return new Vector3(_followingTarget.position.x, _transform.position.y, _followingTarget.position.z);
    }

    private void SimpleMove()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, GetTargetPosition(), _cameraSpeed * Time.deltaTime);
    }

    private void InterpolatedMove()
    {
        _transform.position = Vector3.Lerp(_transform.position, GetTargetPosition(), _cameraSpeed * Time.deltaTime);
    }

    private void DetermineMovementMethod()
    {
        if (_moveType == MoveType.Interpolated)
        {
            Move = InterpolatedMove;
            return;
        }
        Move = SimpleMove;
    }
}
