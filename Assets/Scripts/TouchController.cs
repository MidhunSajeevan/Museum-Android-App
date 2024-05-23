using UnityEngine;

public class TouchController : MonoBehaviour
{
    
    private FixedTouchField FixedTouchField;
    private CameraLook CameraLook;
    void Start()
    {
        FixedTouchField = FindAnyObjectByType<FixedTouchField>();
        CameraLook = FindAnyObjectByType<CameraLook>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraLook.LockAxis = FixedTouchField.TouchDistance;
    }
}
