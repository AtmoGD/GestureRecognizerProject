using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}

public class SwipeState : GestureState
{
    public override void Enter(StateMachine _stateMachine)
    {
        base.Enter(_stateMachine);

        recognizer.Input.swipeDirection = GestureRecognizer.GetSwipeDirection(recognizer.Input.touchStartPosition, recognizer.Input.touchPosition);

        recognizer.InvokeOnSwipe(recognizer.Input.swipeDirection);
    }

    public override void Exit()
    {
        base.Exit();

        recognizer.Input.Reset();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (recognizer.Input.touchEnded)
        {
            recognizer.Input.touchStarted = false;
            recognizer.Input.touchEnded = false;

            recognizer.ChangeState(recognizer.noGestureState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
