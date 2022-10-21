using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureState : State
{
    protected GestureRecognizer recognizer;
    public override void Enter(StateMachine _stateMachine)
    {
        base.Enter(_stateMachine);
        recognizer = (GestureRecognizer)_stateMachine;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
