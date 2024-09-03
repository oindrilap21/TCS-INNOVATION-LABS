using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObjectsOnPlane : MonoBehaviour
{
    [SerializeField]
    GameObject aPrefab; // Assign the "a" prefab in the Inspector
    [SerializeField]
    GameObject bPrefab; // Assign the "b" prefab in the Inspector

    private GameObject spawnedObject;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool canPlaceObject = true;
    private float placementDelay = 5.0f;

    private int selectedObjectType = 0; // 0 for "a", 1 for "b"

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began && canPlaceObject)
        {
            if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;

                if (selectedObjectType == 0)
                {
                    spawnedObject = Instantiate(aPrefab, hitPose.position, hitPose.rotation);
                }
                else if (selectedObjectType == 1)
                {
                    spawnedObject = Instantiate(bPrefab, hitPose.position, hitPose.rotation);
                }

                canPlaceObject = false;
                StartCoroutine(EnablePlacementAfterDelay());

                // Attach PinchScaleObject script to the spawned object
                spawnedObject.AddComponent<PinchScaleObject>();
            }
        }
    }

    IEnumerator EnablePlacementAfterDelay()
    {
        yield return new WaitForSeconds(placementDelay);
        canPlaceObject = true;
    }

    public void SetSelectedObjectType(int objectType)
    {
        selectedObjectType = objectType;
    }
}




