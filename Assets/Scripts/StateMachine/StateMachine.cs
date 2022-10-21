using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    public State previousState;

    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        previousState = currentState;
        currentState = newState;
        currentState.Enter(this);
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.LogicUpdate();
        }
    }

    public void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.PhysicsUpdate();
        }
    }
}
