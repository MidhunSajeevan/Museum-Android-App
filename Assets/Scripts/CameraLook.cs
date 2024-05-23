using UnityEngine;

public class CameraLook : MonoBehaviour
{

    private float XMove;
    private float YMove;
    private float XRoatation;
    internal Vector2 LockAxis;

    private Transform PlayerBody;
    private float Sensitivity = 40f;


    private void Start()
    {
       
        PlayerBody = transform.parent;
    }

    void Update()
    {
        XMove = LockAxis.x * Sensitivity * Time.deltaTime;
        YMove = LockAxis.y * Sensitivity * Time.deltaTime;
        XRoatation -= YMove;
        XRoatation = Mathf.Clamp(XRoatation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRoatation,0,0);
        PlayerBody.Rotate(Vector3.up * XMove);
    }
}
