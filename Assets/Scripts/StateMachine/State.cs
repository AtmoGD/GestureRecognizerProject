using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public StateMachine stateMachine;

    public virtual void Enter(StateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public virtual void Exit() { }
    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate() { }
}
