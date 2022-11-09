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
    public Action OnPrimaryDown;
    public void InvokeOnPrimaryDown() { OnPrimaryDown?.Invoke(); }
    public Action OnPrimaryPerformed;
    public void InvokeOnPrimaryPerformed() { OnPrimaryPerformed?.Invoke(); }
    public Action OnPrimaryUp;
    public void InvokeOnPrimaryUp() { OnPrimaryUp?.Invoke(); }
    public Action OnSecondaryDown;
    public void InvokeOnSecondaryDown() { OnSecondaryDown?.Invoke(); }
    public Action OnSecondaryPerformed;
    public void InvokeOnSecondaryPerformed() { OnSecondaryPerformed?.Invoke(); }
    public Action OnSecondaryUp;
    public void InvokeOnSecondaryUp() { OnSecondaryUp?.Invoke(); }


    public Action<Vector2> OnTap;
    public void InvokeOnTap(Vector2 _position) { OnTap?.Invoke(_position); }
    public Action<Vector2> OnDoubleTap;
    public void InvokeOnDoubleTap(Vector2 _position) { OnDoubleTap?.Invoke(_position); }
    public Action<Vector2> OnPress;
    public void InvokeOnPress(Vector2 _position) { OnPress?.Invoke(_position); }
    public Action<Vector2> OnPressEnd;
    public void InvokeOnPressEnd(Vector2 _position) { OnPressEnd?.Invoke(_position); }
    public Action<SwipeDirection> OnSwipe;
    public void InvokeOnSwipe(SwipeDirection _direction) { OnSwipe?.Invoke(_direction); }
    public Action<Vector2> OnDragStart;
    public void InvokeOnDragStart(Vector2 _position) { OnDragStart?.Invoke(_position); }
    public Action<Vector2, Vector2> OnDrag;
    public void InvokeOnDrag(Vector2 _startPosition, Vector2 _endPosition) { OnDrag?.Invoke(_startPosition, _endPosition); }
    public Action<Vector2, Vector2> OnDragEnd;
    public void InvokeOnDragEnd(Vector2 _startPosition, Vector2 _endPosition) { OnDragEnd?.Invoke(_startPosition, _endPosition); }
    public Action<Vector2> OnMoveStart;
    public void InvokeOnMoveStart(Vector2 _position) { OnMoveStart?.Invoke(_position); }
    public Action<Vector2, Vector2> OnMove;
    public void InvokeOnMove(Vector2 _startPosition, Vector2 _endPosition) { OnMove?.Invoke(_startPosition, _endPosition); }
    public Action<Vector2, Vector2> OnMoveEnd;
    public void InvokeOnMoveEnd(Vector2 _startPosition, Vector2 _endPosition) { OnMoveEnd?.Invoke(_startPosition, _endPosition); }
    public Action<Vector2> OnPinchStart;
    public void InvokeOnPinchStart(Vector2 _position) { OnPinchStart?.Invoke(_position); }
    public Action<Vector2, Vector2> OnPinch;
    public void InvokeOnPinch(Vector2 _startPosition, Vector2 _endPosition) { OnPinch?.Invoke(_startPosition, _endPosition); }
    public Action<Vector2, Vector2> OnPinchEnd;
    public void InvokeOnPinchEnd(Vector2 _startPosition, Vector2 _endPosition) { OnPinchEnd?.Invoke(_startPosition, _endPosition); }
    public Action<Vector2> OnRotateStart;
    public void InvokeOnRotateStart(Vector2 _position) { OnRotateStart?.Invoke(_position); }
    public Action<Vector2, Vector2> OnRotate;
    public void InvokeOnRotate(Vector2 _startPosition, Vector2 _endPosition) { OnRotate?.Invoke(_startPosition, _endPosition); }
    public Action<Vector2, Vector2> OnRotateEnd;
    public void InvokeOnRotateEnd(Vector2 _startPosition, Vector2 _endPosition) { OnRotateEnd?.Invoke(_startPosition, _endPosition); }
    #endregion

    #region States
    public NoGestureState noGestureState = new NoGestureState();
    public TapState tapState = new TapState();
    public PressState pressState = new PressState();
    public MoveState moveState = new MoveState();
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
    [SerializeField] private float minDragDistance = 0.2f;
    public float MinDragDistance { get { return minDragDistance; } }
    #endregion

    #region Input
    [Header("Primary Pointer")]
    private bool primaryDown = false;
    private bool primaryUp = false;
    private Vector2 primaryPosition = Vector2.zero;
    private Vector2 primaryDelta = Vector2.zero;

    [Header("Secondary Pointer")]
    private bool secondaryDown = false;
    private bool secondaryUp = false;
    private Vector2 secondaryPosition = Vector2.zero;
    private Vector2 secondaryDelta = Vector2.zero;
    #endregion

    private void Start()
    {
        inputData = new InputData();
        currentState = noGestureState;
        ChangeState(noGestureState);
    }
    public void OnSingleTap(InputAction.CallbackContext context)
    {
        // if (context.started)
        // {
        //     inputData.Reset();

        //     inputData.touchStarted = true;
        //     inputData.touchStartTime = Time.time;
        //     inputData.touchStartPosition = inputData.touchPosition;
        // }
        // else if (context.canceled)
        // {
        //     inputData.touchEnded = true;
        // }
    }

    public void OnPrimaryInput(InputAction.CallbackContext context)
    {
        print(context.phase);
        if (context.phase == InputActionPhase.Started)
        {
            primaryDown = true;
            InvokeOnPrimaryDown();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            primaryUp = true;
            InvokeOnPrimaryUp();
        }
        else if (context.phase == InputActionPhase.Performed)
        {
            InvokeOnPrimaryPerformed();
        }

        // if (context.started)
        // {
        //     primaryDown = true;
        //     InvokeOnPrimaryDown();
        // }
        // else if (context.performed)
        // {
        //     InvokeOnPrimaryPerformed();
        // }
        // else if (context.canceled)
        // {
        //     primaryUp = true;
        //     InvokeOnPrimaryUp();
        // }
    }

    public void OnSecondaryInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            secondaryDown = true;
            InvokeOnSecondaryDown();
        }
        else if (context.performed)
        {
            InvokeOnSecondaryPerformed();
        }
        else if (context.canceled)
        {
            secondaryUp = true;
            InvokeOnSecondaryUp();
        }
    }

    public void OnPosition(InputAction.CallbackContext context)
    {
        // if (context.performed)
        //     inputData.touchPosition = context.ReadValue<Vector2>();
    }

    public void OnDelta(InputAction.CallbackContext context)
    {
        // if (context.started)
        //     inputData.touchDelta = context.ReadValue<Vector2>();
    }
}
