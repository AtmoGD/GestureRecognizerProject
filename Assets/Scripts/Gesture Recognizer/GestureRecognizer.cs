using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GestureRecognizer : StateMachine
{
    [SerializeField] private InputData inputData = new InputData();
    public InputData Input { get { return inputData; } }

    #region Actions
    public Action<Vector2> OnTap;
    public void InvokeOnTap(Vector2 _position) { OnTap?.Invoke(_position); }
    public Action<Vector2> OnPress;
    public void InvokeOnPress(Vector2 _position) { OnPress?.Invoke(_position); }
    public Action<Vector2> OnDragStart;
    public void InvokeOnDragStart(Vector2 _position) { OnDragStart?.Invoke(_position); }
    public Action<Vector2, Vector2> OnDrag;
    public void InvokeOnDrag(Vector2 _startPosition, Vector2 _endPosition) { OnDrag?.Invoke(_startPosition, _endPosition); }
    public Action<Vector2, Vector2> OnDragEnd;
    public void InvokeOnDragEnd(Vector2 _startPosition, Vector2 _endPosition) { OnDragEnd?.Invoke(_startPosition, _endPosition); }
    public Action<SwipeDirection> OnSwipe;
    public void InvokeOnSwipe(SwipeDirection _direction) { OnSwipe?.Invoke(_direction); }
    #endregion

    #region States
    public NoGestureState noGestureState = new NoGestureState();
    public TapState tapState = new TapState();
    public PressState pressState = new PressState();
    public DragState dragState = new DragState();
    public SwipeState swipeState = new SwipeState();
    public PinchState pinchState = new PinchState();
    public RotateState rotateState = new RotateState();
    #endregion

    #region Settings
    [Header("Settings")]
    [SerializeField] private float tapTime = 0.2f;
    public float TapTime { get { return tapTime; } }
    [SerializeField] private float pressTime = 0.4f;
    public float PressTime { get { return pressTime; } }
    [SerializeField] private float dragTime = 0.3f;
    [SerializeField] private float minDragDistance = 0.2f;
    public float MinDragDistance { get { return minDragDistance; } }
    [SerializeField] private float swipeTime = 0.3f;
    public float SwipeTime { get { return swipeTime; } }
    [SerializeField] private float swipeDistance = 0.2f;
    public float SwipeDistance { get { return swipeDistance; } }
    [SerializeField] private float pinchDistance = 0.2f;
    public float PinchDistance { get { return pinchDistance; } }
    [SerializeField] private float rotateDistance = 0.2f;
    public float RotateDistance { get { return rotateDistance; } }
    #endregion

    public bool IsTap
    {
        get
        {
            return Input.touchStarted && Input.touchEnded && Input.TouchDuration < TapTime;
        }
    }

    public bool IsPress
    {
        get
        {
            return Input.touchStarted && !Input.touchEnded && Input.TouchDuration > PressTime && DragDistance < MinDragDistance && DragDistance < SwipeDistance;
        }
    }

    public bool IsDrag
    {
        get
        {
            return Input.touchStarted && !Input.touchEnded && Input.TouchDuration > TapTime && DragDistance > MinDragDistance;
        }
    }

    public float DragDistance
    {
        get
        {
            return Vector2.Distance(Input.touchStartPosition, Input.touchPosition);
        }
    }

    public bool IsSwipe
    {
        get
        {
            return Input.touchStarted && Input.touchEnded && Input.TouchDuration < SwipeTime && DragDistance > SwipeDistance;
            // return Input.touchEnded && Input.TouchDuration < TapTime && DragDistance > SwipeDistance;
        }
    }

    #region Timer
    private float tapTimer = 0;
    private float pinchTimer = 0;
    private float rotateTimer = 0;
    #endregion

    private void Start()
    {
        inputData = new InputData();
        currentState = noGestureState;
        ChangeState(noGestureState);
    }

    // private new void Update()
    // {
    //     base.Update();

    // return;
    /*
    if the tap timer is less than the tap time its a tap
    if the tap timer is greater than the tap time and the total distance is less than the drag distance its a press
    if the tap timer is greater than the tap time and the total distance is greater than the drag distance its a drag
    if the tap timer is less than the tap time and the total distance is greater than the swipe distance its a swipe
    */

    // if the tap timer is less than the tap time its a tap
    // if (inputData.touchStarted && inputData.touchEnded && (Time.time - inputData.touchStartTime) < tapTime && Vector2.Distance(inputData.touchStartPosition, inputData.touchPosition) > swipeDistance)
    // {
    //     inputData.swipe = true;
    //     inputData.swipeDirection = GetSwipeDirection(inputData.touchStartPosition, inputData.touchPosition);
    //     OnSwipe?.Invoke(inputData.swipeDirection);
    //     return;
    // }

    // if (inputData.touchStarted && !inputData.touchEnded && Vector2.Distance(inputData.touchStartPosition, inputData.touchPosition) > minDragDistance)
    // {
    //     inputData.drag = true;
    //     inputData.dragStart = inputData.touchStartPosition;
    //     OnDragStart?.Invoke(inputData.dragStart);
    //     return;
    // }

    // if (inputData.drag)
    // {
    //     if (inputData.touchEnded)
    //     {
    //         inputData.dragEnd = inputData.touchPosition;
    //         OnDragEnd?.Invoke(inputData.dragStart, inputData.dragEnd);
    //         return;
    //     }
    //     else
    //     {
    //         OnDrag?.Invoke(inputData.dragStart, inputData.touchPosition);
    //         return;
    //     }
    // }

    // if (inputData.touchStarted && inputData.touchEnded && (Time.time - inputData.touchStartTime) < tapTime)
    // {
    //     inputData.tap = true;
    //     OnTap?.Invoke(inputData.touchStartPosition);
    //     return;
    // }

    // if (inputData.touchStarted && !inputData.touchEnded && (Time.time - inputData.touchStartTime) > tapTime)
    // {
    //     inputData.press = true;
    //     OnPress?.Invoke(inputData.touchStartPosition);
    //     return;
    // }

    // if the tap timer is greater than the tap time and the total distance is higher than the drag distance its a drag

    // if the tap timer is less than the tap time and the total distance is higher than the swipe distance its a swipe


    // }

    public static SwipeDirection GetSwipeDirection(Vector2 start, Vector2 end)
    {
        Vector2 direction = end - start;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                return SwipeDirection.Right;
            }
            else
            {
                return SwipeDirection.Left;
            }
        }
        else
        {
            if (direction.y > 0)
            {
                return SwipeDirection.Up;
            }
            else
            {
                return SwipeDirection.Down;
            }
        }
    }

    public void OnSingleTap(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputData.Reset();

            inputData.touchStarted = true;
            inputData.touchStartTime = Time.time;
            inputData.touchStartPosition = inputData.touchPosition;
        }
        else if (context.canceled)
        {
            inputData.touchEnded = true;
        }
    }

    public void OnPosition(InputAction.CallbackContext context)
    {
        if (context.performed)
            inputData.touchPosition = context.ReadValue<Vector2>();
    }

    public void OnDelta(InputAction.CallbackContext context)
    {
        if (context.started)
            inputData.touchDelta = context.ReadValue<Vector2>();
    }
}
