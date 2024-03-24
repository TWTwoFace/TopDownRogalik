using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    protected override void InitBehaviours()
    {
        base.InitBehaviours();
        _behavioursMap[typeof(PlayerBehaviourAlive)] = new PlayerBehaviourAlive(); 
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
