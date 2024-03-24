using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private PlayerMovement _movement;
    private PlayerRotation _rotator;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _rotator = GetComponent<PlayerRotation>();
    }

    protected override void InitBehaviours()
    {
        base.InitBehaviours();
        _behavioursMap[typeof(PlayerBehaviourAlive)] = new PlayerBehaviourAlive(_movement, _rotator); 
    }

    protected override void SetBehaviourByDefault()
    {
        var defaultBehaviour = GetBehaviour<PlayerBehaviourAlive>();
        SetBehaviour(defaultBehaviour);
    }

    protected override void Subscribe()
    {
        
    }

    protected override void Unsubscribe()
    {

    }
}
