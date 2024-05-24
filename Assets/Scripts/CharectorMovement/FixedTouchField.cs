using UnityEngine; // Required for Unity-specific classes and functions
using UnityEngine.EventSystems; // Required for handling UI events

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // The distance the touch has moved
    public Vector2 TouchDistance;

    // The position of the touch in the previous frame
    public Vector2 PointerOld;

    // The ID of the current touch
    protected int PointerId;

    // Whether the touch field is currently pressed
    public bool Pressed;

    // Called when a pointer (mouse or touch) is pressed down on this UI element
    public void OnPointerDown(PointerEventData eventData)
    {
        // Mark the touch field as pressed
        Pressed = true;

        // Store the ID of the current touch
        PointerId = eventData.pointerId;

        // Store the position of the current touch
        PointerOld = eventData.position;
    }

    // Called when a pointer (mouse or touch) is released from this UI element
    public void OnPointerUp(PointerEventData eventData)
    {
        // Mark the touch field as not pressed
        Pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            // If the current pointer ID is valid (within the range of active touches)
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                // Calculate the distance the touch has moved since the last frame
                TouchDistance = Input.touches[PointerId].position - PointerOld;

                // Update the old position to the current position
                PointerOld = Input.touches[PointerId].position;
            }
            else
            {
                // Calculate the distance the mouse has moved since the last frame
                TouchDistance = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;

                // Update the old position to the current mouse position
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            // Reset the touch distance if the touch field is not pressed
            TouchDistance = new Vector2();
        }
    }
}
