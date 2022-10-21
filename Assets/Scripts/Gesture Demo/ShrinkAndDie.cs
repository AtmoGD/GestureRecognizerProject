using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndDie : MonoBehaviour
{
    public float shrinkSpeed = 0.1f;
    public float dieAfter = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dieAfter -= Time.deltaTime;

        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, shrinkSpeed * Time.deltaTime);

        if (dieAfter <= 0)
        {
            Destroy(gameObject);
        }
    }
}
