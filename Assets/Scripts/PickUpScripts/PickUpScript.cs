using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;

    public float pickUpRange = 50f; // How far the player can pick up the object
    private float rotationSensitivity = 0.1f; // Speed of object rotation relative to touch movement
    private GameObject heldObj; // Object being picked up
    private Rigidbody heldObjRb; // Rigidbody of the object being picked up
    private bool canDrop = true; // Prevents dropping while rotating
    private int LayerNumber; // Layer index for held object

    private float lastTapTime = 0f; // Time of the last tap
    private float doubleTapDelay = 0.3f; // Maximum delay between taps to count as double tap
    private Vector2 lastTouchPosition; // Last touch position for rotation

    private TouchController touchControler;
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("PickUpLayer"); // Adjust layer name if different
        touchControler = FindAnyObjectByType<TouchController>();
       
    }

    void Update()
    {
        if (IsDoubleTap())
        {
            if (heldObj == null) // If currently not holding anything
            {
                // Perform a raycast from the camera to the tap position
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit, pickUpRange))
                {
                    // Ensure the object has the "CanPickUp" tag
                    if (hit.transform.gameObject.tag == "CanPickUp")
                    {
                       
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                if (canDrop)
                {
                    StopClipping(); // Prevent object clipping through walls
                    DropObject();
                }
            }
        }

        if (heldObj != null) // If player is holding an object
        {
            MoveObject(); // Keep object position at holdPos
            RotateObject(); // Rotate object based on touch input
        }
    }

    bool IsDoubleTap()
    {
        // Check for touch input
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                // Check the time between taps
                if (Time.time - lastTapTime < doubleTapDelay)
                {
                    lastTapTime = 0f; // Reset last tap time
                    return true;
                }
                else
                {
                    lastTapTime = Time.time;
                }
            }
        }
        return false;
    }

    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) // Ensure the object has a Rigidbody
        {
            heldObj = pickUpObj; // Assign heldObj to the hit object
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); // Assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; // Parent object to hold position
            heldObj.layer = LayerNumber; // Change object layer to holdLayer
            // Prevent collision with player
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void DropObject()
    {
        // Re-enable collision with player
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; // Assign object back to default layer
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; // Unparent object
        heldObj = null; // Undefine game object
    }

    void MoveObject()
    {
        // Keep object position the same as holdPosition
        heldObj.transform.position = holdPos.transform.position;
    }

    void RotateObject()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                touchControler.enabled = false;
                canDrop = false; // Prevent dropping while rotating

                // Calculate rotation based on touch movement
                Vector2 touchDelta = touch.deltaPosition;
                float XaxisRotation = touchDelta.x * rotationSensitivity;
                float YaxisRotation = touchDelta.y * rotationSensitivity;

                heldObj.transform.Rotate(Vector3.down, XaxisRotation, Space.World);
                heldObj.transform.Rotate(Vector3.right, -YaxisRotation, Space.World);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                touchControler.enabled = true;
                canDrop = true; // Allow dropping when touch ends
            }
        }
    }

    void StopClipping()
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); // Distance from holdPos to camera
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        if (hits.Length > 1)
        {
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); // Offset downward to prevent clipping
        }
    }
}
