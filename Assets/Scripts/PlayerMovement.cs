using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(5f, 10f)]
    public float MovingSpeed = 5f;

    private FixedJoystick joystick;
    private CharacterController characterController;
    void Start()
    {
        References();


    }

   
    void Update()
    {
        Vector3 movement = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;

        characterController.Move(movement * MovingSpeed * Time.deltaTime);
    }

    #region REFERENCES
    private void References()
    {
        characterController = GetComponent<CharacterController>();
        joystick = FindAnyObjectByType<FixedJoystick>();
 
    }
    #endregion
}
