using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float jumpHeight = 2f;
    public float gravity = -20f;
    private int jumpsRemaining = 2;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        ApplyGravity();
        HandleJump();
        HandleCrouch();



    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        controller.Move(direction *  moveSpeed * Time.deltaTime);
        float currentSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = 16f;
        }

        controller.Move(direction * currentSpeed * Time.deltaTime);
    }
    public float standingHeight = 2f;
    public float crouchingHeight = 1f;

    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = crouchingHeight;
        }
        else
        {
            controller.height = standingHeight;
        }
    }
    void HandleJump()
    {
        // Inside your jump logic: 
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpsRemaining--;
        }

        if (controller.isGrounded)
        {
            jumpsRemaining = 2;
        }
    }
    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}