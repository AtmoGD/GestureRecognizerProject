using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GestureVisualization : MonoBehaviour
{
    [SerializeField] private GestureRecognizer gestureRecognizer = null;
    [SerializeField] private GameObject canvas = null;
    [SerializeField] private TMP_Text primaryText = null;
    [SerializeField] private TMP_Text secondaryText = null;
    [SerializeField] private TMP_Text flyingTextPrefab = null;
    [SerializeField] private GameObject tapPrefab = null;
    [SerializeField] private GameObject pressPrefab = null;
    [SerializeField] private GameObject swipePrefab = null;
    [SerializeField] private GameObject movePrefab = null;
    [SerializeField] private GameObject dragPrefab = null;
    [SerializeField] private GameObject pinchPrefab = null;
    [SerializeField] private GameObject rotatePrefab = null;

    private void Start()
    {
        gestureRecognizer.OnPrimaryDown += OnPrimaryDown;
        gestureRecognizer.OnPrimaryPerformed += OnPrimaryPerformed;
        gestureRecognizer.OnPrimaryUp += OnPrimaryUp;
        gestureRecognizer.OnSecondaryDown += OnSecondaryDown;
        gestureRecognizer.OnSecondaryPerformed += OnSecondaryPerformed;
        gestureRecognizer.OnSecondaryUp += OnSecondaryUp;

        gestureRecognizer.OnTap += Tapped;
        gestureRecognizer.OnDoubleTap += DoubleTapped;
        gestureRecognizer.OnPress += Pressed;
        gestureRecognizer.OnSwipe += Swiped;
        gestureRecognizer.OnMoveStart += MoveStarted;
        gestureRecognizer.OnMove += Moved;
        gestureRecognizer.OnMoveEnd += MoveEnded;
        gestureRecognizer.OnDragStart += DragStarted;
        gestureRecognizer.OnDrag += Dragged;
        gestureRecognizer.OnDragEnd += DragEnded;
        gestureRecognizer.OnPinchStart += PinchStarted;
        gestureRecognizer.OnPinch += Pinched;
        gestureRecognizer.OnPinchEnd += PinchEnded;
        gestureRecognizer.OnRotateStart += RotateStarted;
        gestureRecognizer.OnRotate += Rotated;
        gestureRecognizer.OnRotateEnd += RotateEnded;
    }

    private void OnPrimaryDown()
    {
        primaryText.text = "Primary Down";
        TMP_Text flyingText = Instantiate(flyingTextPrefab, secondaryText.transform.position, Quaternion.identity, primaryText.transform.parent);
        flyingText.text = "Primary Down";
    }

    private void OnPrimaryPerformed()
    {
        primaryText.text = "Primary Performed";
        TMP_Text flyingText = Instantiate(flyingTextPrefab, secondaryText.transform.position, Quaternion.identity, canvas.transform);
        flyingText.text = "Primary Performed";
    }

    private void OnPrimaryUp()
    {
        primaryText.text = "Primary Up";
        TMP_Text flyingText = Instantiate(flyingTextPrefab, secondaryText.transform.position, Quaternion.identity, canvas.transform);
        flyingText.text = "Primary Up";
    }

    private void OnSecondaryDown()
    {
        secondaryText.text = "Secondary Down";
        TMP_Text flyingText = Instantiate(flyingTextPrefab, secondaryText.transform.position, Quaternion.identity, canvas.transform);
        flyingText.text = "Secondary Down";
    }

    private void OnSecondaryPerformed()
    {
        secondaryText.text = "Secondary Performed";
        TMP_Text flyingText = Instantiate(flyingTextPrefab, secondaryText.transform.position, Quaternion.identity, canvas.transform);
        flyingText.text = "Secondary Performed";
    }

    private void OnSecondaryUp()
    {
        secondaryText.text = "Secondary Up";
        TMP_Text flyingText = Instantiate(flyingTextPrefab, secondaryText.transform.position, Quaternion.identity, canvas.transform);
        flyingText.text = "Secondary Up";
    }

    private void Tapped(Vector2 _position)
    {
        primaryText.text = "Tapped at " + _position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_position);
        Instantiate(tapPrefab, worldPosition, Quaternion.identity);
    }

    private void DoubleTapped(Vector2 _position)
    {
        primaryText.text = "Double Tapped at " + _position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_position);
        Instantiate(tapPrefab, worldPosition, Quaternion.identity);
    }

    private void Pressed(Vector2 _position)
    {
        primaryText.text = "Pressed at " + _position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_position);
        Instantiate(pressPrefab, worldPosition, Quaternion.identity);
    }
    private void Swiped(SwipeDirection _direction)
    {
        primaryText.text = "Swiped " + _direction;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Camera.main.pixelRect.center);
        Instantiate(swipePrefab, worldPosition, Quaternion.identity);
    }

    private void MoveStarted(Vector2 _position)
    {
        primaryText.text = "Move Started at " + _position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_position);
        Instantiate(movePrefab, worldPosition, Quaternion.identity);
    }

    private void Moved(Vector2 _start, Vector2 _end)
    {
        primaryText.text = "Moved from " + _start + " to " + _end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_end);
        Instantiate(movePrefab, worldPosition, Quaternion.identity);
    }

    private void MoveEnded(Vector2 _start, Vector2 _end)
    {
        primaryText.text = "Move Ended from " + _start + " to " + _end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_end);
        Instantiate(movePrefab, worldPosition, Quaternion.identity);
    }

    private void DragStarted(Vector2 _position)
    {
        primaryText.text = "Drag started at " + _position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_position);
        Instantiate(pressPrefab, worldPosition, Quaternion.identity);
    }

    private void Dragged(Vector2 _start, Vector2 _end)
    {
        primaryText.text = "Dragged from " + _start + " to " + _end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_end);
        Instantiate(dragPrefab, worldPosition, Quaternion.identity);
    }

    private void DragEnded(Vector2 _start, Vector2 _end)
    {
        primaryText.text = "Drag ended from " + _start + " to " + _end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_end);
        Instantiate(dragPrefab, worldPosition, Quaternion.identity);
    }

    private void PinchStarted(Vector2 _position)
    {
        primaryText.text = "Pinch started at " + _position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_position);
        Instantiate(pinchPrefab, worldPosition, Quaternion.identity);
    }

    private void Pinched(Vector2 _start, Vector2 _end)
    {
        primaryText.text = "Pinched from " + _start + " to " + _end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_end);
        Instantiate(pinchPrefab, worldPosition, Quaternion.identity);
    }

    private void PinchEnded(Vector2 _start, Vector2 _end)
    {
        primaryText.text = "Pinch ended from " + _start + " to " + _end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_end);
        Instantiate(pinchPrefab, worldPosition, Quaternion.identity);
    }

    private void RotateStarted(Vector2 _position)
    {
        primaryText.text = "Rotate started at " + _position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_position);
        Instantiate(rotatePrefab, worldPosition, Quaternion.identity);
    }

    private void Rotated(Vector2 _start, Vector2 _end)
    {
        primaryText.text = "Rotated from " + _start + " to " + _end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_end);
        Instantiate(rotatePrefab, worldPosition, Quaternion.identity);
    }

    private void RotateEnded(Vector2 _start, Vector2 _end)
    {
        primaryText.text = "Rotate ended from " + _start + " to " + _end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(_end);
        Instantiate(rotatePrefab, worldPosition, Quaternion.identity);
    }
}
