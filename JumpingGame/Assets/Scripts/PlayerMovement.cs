// This script handles the movement and physics of the player character in a 2D environment.

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Camera camera;
    private new Rigidbody2D rigidbody;

    private Vector2 velocity; // Stores the current velocity of the player.
    private float inputAxis; // Represents the input received from the horizontal axis.

    public float moveSpeed = 8f; // The speed at which the player moves horizontally.
    public float maxJumpHeight = 5f; // The maximum height the player can jump.
    public float maxJumpTime = 1f; // The duration of the maximum jump.

    // Computed properties for jumpForce and gravity to calculate them based on maxJumpHeight and maxJumpTime.
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    public bool grounded { get; private set; } // Indicates whether the player is grounded (touching the ground).
    public bool jumping { get; private set; } // Indicates whether the player is currently jumping.

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Cache the Rigidbody2D component of the player.
        camera = Camera.main; // Cache the main camera in the scene.
    }

    private void Update()
    {
        HorizontalMovement(); // Handles the player's horizontal movement.

        grounded = rigidbody.Raycast(Vector2.down, LayerMask.GetMask("Default")); // Checks if the player is grounded by raycasting downwards.

        // Debug.Log("here" + grounded); // Debug line to display the grounded status.

        if (grounded)
        {
            GroundedMovement(); // Perform grounded movement actions like jumping.
        }

        ApplyGravity(); // Apply gravity to the player's vertical movement.
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal"); // Get the horizontal input axis (-1 to 1).
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime); // Calculate horizontal velocity.

        // If the player is about to collide with a wall in the current direction of movement, set horizontal velocity to 0.
        if (rigidbody.Raycast(Vector2.right * velocity.x, LayerMask.GetMask("Default")))
        {
            velocity.x = 0f;
        }

        // Face the player character to the right direction based on its horizontal velocity.
        if (velocity.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (velocity.x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f); // Ensure the player's vertical velocity doesn't go below 0.
        jumping = velocity.y > 0f; // Set jumping status based on whether the player's vertical velocity is greater than 0.

        if (Input.GetButtonDown("Jump")) // Check for jump input.
        {
            velocity.y = jumpForce; // Apply jump force to the player's vertical velocity.
            jumping = true; // Set jumping status to true as the player is now jumping.
        }
    }

    private void ApplyGravity()
    {
        // Check if the player is falling (negative vertical velocity) or not holding the jump button, and adjust the gravity multiplier accordingly.
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        // Apply gravity to the player's vertical velocity.
        velocity.y += gravity * multiplier * Time.deltaTime;

        // Prevent the player from falling too fast by setting a minimum vertical velocity.
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position; // Get the current position of the player.
        position += velocity * Time.fixedDeltaTime; // Apply the velocity over time to the position.

        // Ensure the player stays within the screen boundaries based on the main camera's viewport.
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.7f, rightEdge.x - 0.7f);

        rigidbody.MovePosition(position); // Move the player to the new position using the Rigidbody2D.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) // Check if the player collides with an object on the "Enemy" layer.
        {
            if (transform.DotTest(collision.transform, Vector2.down)) // Check if the player is colliding from above with the enemy.
            {
                velocity.y = jumpForce / 2f; // Apply half of the jump force to the player's vertical velocity to bounce off the enemy.
                jumping = true; // Set jumping status to true as the player is now bouncing.
            }
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer("PowerUp")) // Check if the collision is not with an object on the "PowerUp" layer.
        {
            if (transform.DotTest(collision.transform, Vector2.up)) // Check if the player is colliding from below with an object.
            {
                velocity.y = 0f; // Set the vertical velocity to 0 to stop the player's upward movement.
            }
        }
    }
}
