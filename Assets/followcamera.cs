using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour
{
    public Transform myTransform;
    public float speed;

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    void Start()
    {
        transform.position = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float restrictX = Mathf.Clamp(myTransform.position.x, minX, maxX);
        float restrictY = Mathf.Clamp(myTransform.position.y, minY, maxY);
        if (myTransform != null)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(restrictX,restrictY), speed);
        }
    }
}
