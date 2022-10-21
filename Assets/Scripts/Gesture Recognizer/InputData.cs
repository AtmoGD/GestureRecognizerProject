using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InputData
{
    public bool touchStarted = false;
    public bool touchEnded = false;
    public Vector2 touchStartPosition = Vector2.zero;
    public Vector2 touchPosition = Vector2.zero;
    public Vector2 touchDelta = Vector2.zero;
    public float touchStartTime = 0f;
    public float TouchDuration { get { return Time.time - touchStartTime; } }
    public bool tap = false;
    public bool press = false;
    public bool drag = false;
    public Vector2 dragStart = Vector2.zero;
    public Vector2 dragEnd = Vector2.zero;
    public bool swipe = false;
    public SwipeDirection swipeDirection = SwipeDirection.Down;

    public void Reset()
    {
        touchStarted = false;
        touchEnded = false;
        tap = false;
        press = false;
        drag = false;
        swipe = false;
    }
}