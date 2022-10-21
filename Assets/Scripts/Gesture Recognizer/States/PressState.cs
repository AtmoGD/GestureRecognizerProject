using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressState : GestureState
{
    public override void Enter(StateMachine _stateMachine)
    {
        base.Enter(_stateMachine);

        recognizer.InvokeOnPress(recognizer.Input.touchPosition);

        // Debug.Log("PressState: Enter");
    }

    public override void Exit()
    {
        base.Exit();

        // Debug.Log("PressState: Exit");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (recognizer.Input.touchEnded)
        {
            recognizer.ChangeState(recognizer.noGestureState);
        }

        if (recognizer.IsDrag)
        {
            recognizer.ChangeState(recognizer.dragState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}