using UnityEngine;

public class TouchController : MonoBehaviour
{
   
    private FixedTouchField fixedTouchField;
    private CameraLook cameraLook;

   
    void Start()
    {
        // Initialize the fixed touch field and camera look references
        fixedTouchField = FindAnyObjectByType<FixedTouchField>();
        cameraLook = FindAnyObjectByType<CameraLook>();
    }


    void Update()
    {
       
        cameraLook.LockAxis = fixedTouchField.TouchDistance;
    }
}
