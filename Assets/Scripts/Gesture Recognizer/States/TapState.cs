using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapState : GestureState
{

    private float tapStartTime = 0f;
    private bool tapEnded = false;

    public override void Enter(StateMachine _stateMachine)
    {
        base.Enter(_stateMachine);

        tapStartTime = 0f;
        tapEnded = false;
    }

    public override void Exit()
    {
        base.Exit();

        // recognizer.Input.Reset();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        tapStartTime += Time.deltaTime;

        if (recognizer.Input.touchEnded && tapEnded)
        {
            recognizer.InvokeOnDoubleTap(recognizer.Input.touchStartPosition);
            recognizer.ChangeState(recognizer.noGestureState);
            return;
            // if (tapEnded)
            // {
            //     recognizer.InvokeOnDoubleTap(recognizer.Input.touchPosition);
            //     recognizer.ChangeState(recognizer.noGestureState);
            //     return;
            // }
            // else
            // {
            recognizer.InvokeOnTap(recognizer.Input.touchStartPosition);
            recognizer.Input.touchStarted = false;
            recognizer.Input.touchEnded = false;
            tapEnded = true;
            // }
        }
        else
        {
            if (recognizer.Input.touchEnded)
            {
                recognizer.InvokeOnTap(recognizer.Input.touchStartPosition);
                recognizer.Input.touchStarted = false;
                recognizer.Input.touchEnded = false;
                tapEnded = true;
                return;
            }

            // if(recognizer.Input.)

            if (tapEnded && recognizer.Input.touchStarted && tapStartTime > recognizer.TapTime)
            {
                recognizer.InvokeOnDoubleTap(recognizer.Input.touchStartPosition);
                recognizer.ChangeState(recognizer.noGestureState);
                return;
            }


            if (recognizer.Input.touchEnded)
            {

                recognizer.InvokeOnDoubleTap(recognizer.Input.touchStartPosition);
                recognizer.ChangeState(recognizer.noGestureState);
                return;
            }
            else
            {
                if (tapStartTime > recognizer.TapTime)
                {
                    recognizer.ChangeState(recognizer.noGestureState);
                }
                if (tapStartTime > recognizer.PressTime)
                {
                    recognizer.InvokeOnPress(recognizer.Input.touchStartPosition);
                    recognizer.ChangeState(recognizer.pressState);
                    return;
                }
            }



            // if (!tapEnded)
            // {
            //     if (tapStartTime > recognizer.TapTime)
            //     {
            //         recognizer.InvokeOnDoubleTap(recognizer.Input.touchStartPosition);
            //         recognizer.ChangeState(recognizer.noGestureState);
            //         return;
            //     }
            // }
            // else
            // {
            //     if (tapStartTime > recognizer.PressTime)
            //     {
            //         recognizer.InvokeOnPress(recognizer.Input.touchStartPosition);
            //         recognizer.ChangeState(recognizer.pressState);
            //         return;
            //     }

            //     if (Vector2.Distance(recognizer.Input.touchStartPosition, recognizer.Input.touchPosition) > recognizer.MinDragDistance)
            //     {
            //         recognizer.ChangeState(recognizer.dragState);
            //         return;
            //     }
            // }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
