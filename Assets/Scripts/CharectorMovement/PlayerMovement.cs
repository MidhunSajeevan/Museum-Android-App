using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(5f, 10f)]
    public float MovingSpeed = 5f; // Player movement speed

    public float Gravity = -9.81f; // Gravity value
    private Vector3 velocity; // Velocity vector for gravity

    private FixedJoystick joystick; // Reference to the joystick
    private CharacterController characterController; // Reference to the CharacterController

    void Start()
    {
        References(); // Initialize references
    }

    void FixedUpdate()
    {
        // Calculate movement direction based on joystick input
        Vector3 movement = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;

        // Apply movement to the character
        characterController.Move(movement * MovingSpeed * Time.deltaTime);

        // Apply gravity
        velocity.y += Gravity * Time.deltaTime; // Update velocity with gravity
        characterController.Move(velocity * Time.deltaTime); // Apply velocity to the character
    }

    #region REFERENCES
    private void References()
    {
        // Get the CharacterController component attached to the player
        characterController = GetComponent<CharacterController>();

        // Find the joystick in the scene
        joystick = FindAnyObjectByType<FixedJoystick>();
    }
    #endregion
}
