using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected Dictionary<Type, IBehaviour> _behavioursMap;
    protected IBehaviour _currentBehaviour;

    protected void Start()
    {
        InitBehaviours();
        SetBehaviourByDefault();
    }

    private void Update()
    {
        _currentBehaviour.Update();
    }

    protected virtual void InitBehaviours()
    {
        _behavioursMap = new Dictionary<Type, IBehaviour>();
    }

    protected void SetBehaviour(IBehaviour newBehaviour)
    {
        if (newBehaviour == _currentBehaviour)
        {
            return;
        }
        _currentBehaviour?.Exit();
        _currentBehaviour = newBehaviour;
        _currentBehaviour?.Enter();
    }

    protected IBehaviour GetBehaviour<T>() where T : IBehaviour
    {
        var type = typeof(T);
        return _behavioursMap[type];
    }

    protected virtual void SetBehaviourByDefault()
    {
        return;
    }

    protected virtual void Subscribe()
    {
        Debug.Log("Suscribed");
        return;
    }

    protected virtual void Unsubscribe()
    {
        return;
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
        Debug.Log($"Object {gameObject.name} deleted");
    }
}
