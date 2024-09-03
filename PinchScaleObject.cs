using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchScaleObject : MonoBehaviour
{
    private bool isSelected = false;
    private float initialDistance;

    void OnMouseDown()
    {
        isSelected = true;
        initialDistance = Vector2.Distance(Input.mousePosition, transform.position);
    }

    void OnMouseUp()
    {
        isSelected = false;
    }

    void Update()
    {
        if (isSelected)
        {
            if (Input.touchCount == 2)
            {
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);
                float currentDistance = Vector2.Distance(touch0.position, touch1.position);
                float scaleFactor = currentDistance / initialDistance;
                transform.localScale *= scaleFactor;
                initialDistance = currentDistance;
            }
        }
    }
}

