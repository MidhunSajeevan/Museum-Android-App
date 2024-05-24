using UnityEngine;

public class CameraLook : MonoBehaviour
{

    private float XMove;
    private float YMove;
    private float XRoatation;
    internal Vector2 LockAxis;

    private Transform PlayerBody;
    [Range(10f, 40f)]
    public float Sensitivity = 40f;


    private void Start()
    {
       //acces the player body for rotation
        PlayerBody = transform.parent;
    }

    void Update()
    {
        XMove = LockAxis.x * Sensitivity * Time.deltaTime;
        YMove = LockAxis.y * Sensitivity * Time.deltaTime;
        XRoatation -= YMove;
        XRoatation = Mathf.Clamp(XRoatation, -90f, 90f);

        //rotate the camera according to the input
        transform.localRotation = Quaternion.Euler(XRoatation,0,0);
        //rotate the player body 
        PlayerBody.Rotate(Vector3.up * XMove);
    }
}
