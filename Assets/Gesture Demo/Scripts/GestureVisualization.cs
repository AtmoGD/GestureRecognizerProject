using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GestureVisualization : MonoBehaviour
{
    [SerializeField] private GestureRecognizer gestureRecognizer = null;
    [SerializeField] private TMP_Text text = null;
    [SerializeField] private GameObject tapPrefab = null;
    [SerializeField] private GameObject pressPrefab = null;
    [SerializeField] private GameObject dragPrefab = null;
    [SerializeField] private GameObject swipePrefab = null;

    private void Start()
    {
        gestureRecognizer.OnTap += Tapped;
        gestureRecognizer.OnDoubleTap += DoubleTapped;
        gestureRecognizer.OnPress += Pressed;
        gestureRecognizer.OnDragStart += DragStarted;
        gestureRecognizer.OnDrag += Dragged;
        gestureRecognizer.OnDragEnd += DragEnded;
        gestureRecognizer.OnSwipe += Swiped;
    }

    private void Tapped(Vector2 position)
    {
        text.text = "Tapped at " + position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
        Instantiate(tapPrefab, worldPosition, Quaternion.identity);
    }

    private void DoubleTapped(Vector2 position)
    {
        text.text = "Double Tapped at " + position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
        Instantiate(tapPrefab, worldPosition, Quaternion.identity);
    }

    private void Pressed(Vector2 position)
    {
        text.text = "Pressed at " + position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
        Instantiate(pressPrefab, worldPosition, Quaternion.identity);
    }

    private void DragStarted(Vector2 position)
    {
        text.text = "Drag started at " + position;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
        Instantiate(pressPrefab, worldPosition, Quaternion.identity);
    }

    private void Dragged(Vector2 start, Vector2 end)
    {
        text.text = "Dragged from " + start + " to " + end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(end);
        Instantiate(dragPrefab, worldPosition, Quaternion.identity);
    }

    private void DragEnded(Vector2 start, Vector2 end)
    {
        text.text = "Drag ended from " + start + " to " + end;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(end);
        Instantiate(dragPrefab, worldPosition, Quaternion.identity);
    }

    private void Swiped(SwipeDirection direction)
    {
        text.text = "Swiped " + direction;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(gestureRecognizer.Input.touchPosition);
        Instantiate(swipePrefab, worldPosition, Quaternion.identity);
    }
}
