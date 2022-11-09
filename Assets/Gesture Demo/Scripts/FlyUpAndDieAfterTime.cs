using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUpAndDieAfterTime : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] float timeToLive = 1f;
    [SerializeField] float speed = 1f;

    float timeAlive = 0f;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= timeToLive)
        {
            Destroy(gameObject);
        }
        else
        {
            rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;
        }
    }
}
