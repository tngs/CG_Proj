using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;    // Movement speed
    [SerializeField] float jumpForce = 3.0f;    // Jump force
    [SerializeField] CharacterController controller; // Reference to the CharacterController component

    private Vector3 velocity;         // Player's velocity
    private bool isGrounded;          // Is the player grounded?

    [SerializeField] Transform groundCheck;     // Position for ground check
    [SerializeField] float groundDistance = 0.4f; // Radius for ground check
    [SerializeField] LayerMask groundMask;      // Mask for what is considered ground

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.Instance.isPlayerAlive)
        {
            // Check if the player is grounded
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -5f; // Reset velocity when on the ground
            }

            // Get input for movement
            float x = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
            float z = Input.GetAxis("Vertical");   // W/S or Up/Down arrow

            Vector3 move = transform.right * x + transform.forward * z;

            // Apply movement
            controller.Move(move * moveSpeed * Time.deltaTime);

            // Jump
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
            }

            // Apply gravity
            velocity.y += Physics.gravity.y * Time.deltaTime;

            // Move the player based on velocity
            controller.Move(velocity * Time.deltaTime);
        }
    }
}