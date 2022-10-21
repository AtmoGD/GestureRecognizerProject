using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGestureState : GestureState
{
    public override void Enter(StateMachine _stateMachine)
    {
        base.Enter(_stateMachine);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (recognizer.IsSwipe) { recognizer.ChangeState(recognizer.swipeState); return; }

        if (recognizer.IsTap) { recognizer.ChangeState(recognizer.tapState); return; }

        if (recognizer.IsPress) { recognizer.ChangeState(recognizer.pressState); return; }


        if (recognizer.IsDrag) { recognizer.ChangeState(recognizer.dragState); return; }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}