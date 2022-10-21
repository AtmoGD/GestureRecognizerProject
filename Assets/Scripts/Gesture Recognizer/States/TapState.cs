using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapState : GestureState
{

    public override void Enter(StateMachine _stateMachine)
    {
        base.Enter(_stateMachine);

        recognizer.InvokeOnTap(recognizer.Input.touchPosition);
        recognizer.Input.touchStarted = false;
        recognizer.Input.touchEnded = false;

        recognizer.ChangeState(recognizer.noGestureState);
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
