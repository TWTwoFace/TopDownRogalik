using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("Rotating properties")]
    [SerializeField] private float _speed;

    [Header("Visuals")] 
    [SerializeField] private Transform _visualsTransform;

    private Vector3 _lastRotation;


    public void RotateTo(Vector3 moveVector)
    {
        Vector3 direction = DetermineDirection(moveVector);
        _visualsTransform.rotation = Quaternion.LookRotation(direction);
    }

    private Vector3 DetermineDirection(Vector3 direction)
    {
        if(direction == Vector3.zero)
        {
            if (_lastRotation == null)
            {
                _lastRotation = Vector3.forward;
            }
            return _lastRotation;
        }
        _lastRotation = direction;
        return direction;
    }
}
