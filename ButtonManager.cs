using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Button aButton;  // Reference to the "a" button in the Inspector
    [SerializeField]
    private Button bButton;  // Reference to the "b" button in the Inspector
    [SerializeField]
    private PlaceObjectsOnPlane objectPlacer;  // Reference to the PlaceObjectsOnPlane script

    void Start()
    {
        // Add click event listeners to the buttons
        aButton.onClick.AddListener(SelectA);
        bButton.onClick.AddListener(SelectB);
    }

    void SelectA()
    {
        objectPlacer.SetSelectedObjectType(0); // 0 for object "a"
    }

    void SelectB()
    {
        objectPlacer.SetSelectedObjectType(1); // 1 for object "b"
    }
}


