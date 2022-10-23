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
    public Action<Vector2> OnDoubleTap;
    public void InvokeOnDoubleTap(Vector2 _position) { OnDoubleTap?.Invoke(_position); }
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

    // [SerializeField] private float doubleTapTime = 0.2f;
    // public float DoubleTapTime { get { return doubleTapTime; } }




    [SerializeField] private float pressTime = 0.4f;
    public float PressTime { get { return pressTime; } }
    // [SerializeField] private float dragTime = 0.3f;
    // public float DragTime { get { return dragTime; } }
    [SerializeField] private float minDragDistance = 0.2f;
    public float MinDragDistance { get { return minDragDistance; } }
    // [SerializeField] private float swipeTime = 0.3f;
    // public float SwipeTime { get { return swipeTime; } }
    // [SerializeField] private float swipeDistance = 0.2f;
    // public float SwipeDistance { get { return swipeDistance; } }
    // [SerializeField] private float pinchDistance = 0.2f;
    // public float PinchDistance { get { return pinchDistance; } }
    // [SerializeField] private float rotateDistance = 0.2f;
    // public float RotateDistance { get { return rotateDistance; } }
    #endregion

    private void Start()
    {
        inputData = new InputData();
        currentState = noGestureState;
        ChangeState(noGestureState);
    }

    public bool IsTap
    {
        get
        {
            // return Input.touchStarted && Input.touchEnded && Input.TouchDuration < TapTime;
            return Input.touchStarted;
        }
    }

    // public bool IsPress
    // {
    //     get
    //     {
    //         return Input.touchStarted && !Input.touchEnded && Input.TouchDuration > PressTime && DragDistance < MinDragDistance && DragDistance < SwipeDistance;
    //     }
    // }

    // public bool IsDrag
    // {
    //     get
    //     {
    //         return Input.touchStarted && !Input.touchEnded && Input.TouchDuration > DragTime && DragDistance > MinDragDistance;
    //     }
    // }

    public float DragDistance
    {
        get
        {
            return Vector2.Distance(Input.touchStartPosition, Input.touchPosition);
        }
    }

    // public bool IsSwipe
    // {
    //     get
    //     {
    //         // return Input.touchStarted && Input.touchEnded && Input.TouchDuration < SwipeTime && DragDistance > SwipeDistance;
    //         // return Input.touchStarted && Input.TouchDuration < SwipeTime && DragDistance > SwipeDistance;
    //         return Input.touchDelta.magnitude > SwipeDistance;
    //     }
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
