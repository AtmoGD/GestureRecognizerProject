using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragState : GestureState
{
    public override void Enter(StateMachine _stateMachine)
    {
        base.Enter(_stateMachine);

        recognizer.InvokeOnDragStart(recognizer.Input.touchPosition);
    }

    public override void Exit()
    {
        base.Exit();

        recognizer.Input.Reset();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        recognizer.InvokeOnDrag(recognizer.Input.touchStartPosition, recognizer.Input.touchPosition);

        if (recognizer.Input.touchEnded)
        {
            recognizer.InvokeOnDragEnd(recognizer.Input.touchStartPosition, recognizer.Input.touchPosition);

            recognizer.ChangeState(recognizer.noGestureState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
