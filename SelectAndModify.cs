using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAndModify : MonoBehaviour
{
    private bool isSelected = false;
    private Vector2 initialTouchPosition;
    private float initialScale;

    void OnMouseDown()
    {
        isSelected = true;
        initialTouchPosition = Input.GetTouch(0).position;
        initialScale = transform.localScale.x;
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
                // Calculate the pinch scale factor
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);
                Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
                float touchDeltaMag = (touch0.position - touch1.position).magnitude;
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
                float scaleMultiplier = 0.005f; // Adjust this value for sensitivity

                // Update the object's scale
                float newScale = initialScale + deltaMagnitudeDiff * scaleMultiplier;
                newScale = Mathf.Clamp(newScale, 0.1f, 10f); // Adjust min and max scale limits as needed
                transform.localScale = new Vector3(newScale, newScale, newScale);
            }
        }
    }
}



