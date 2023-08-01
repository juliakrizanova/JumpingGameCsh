using UnityEngine; // Import the UnityEngine namespace for accessing Unity's functionality.

public class EntityMovement : MonoBehaviour
{
    public float speed = 30f; // Public variable to define the movement speed of the entity.
    public Vector2 direction = Vector2.left; // Public variable to set the initial movement direction to the left.

    private new Rigidbody2D rigidbody; // Private reference to the entity's Rigidbody2D component.
    private Vector2 velocity; // Private variable to hold the current movement velocity of the entity.

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the entity.
        enabled = false; // Disable this script when the entity is initialized, so it doesn't move until it becomes visible.
    }

    private void OnBecameVisible()
    {
        enabled = true; // Enable this script when the entity becomes visible in the camera's view.
    }

    private void OnBecameInvisible()
    {
        enabled = false; // Disable this script when the entity goes out of the camera's view to save processing power.
    }

    private void OnEnable()
    {
        rigidbody.WakeUp(); // Make sure the Rigidbody2D is awake and active when the script is enabled.
    }

    private void OnDisable()
    {
        rigidbody.velocity = Vector2.zero; // Reset the velocity of the entity to zero when the script is disabled.
        rigidbody.Sleep(); // Put the Rigidbody2D to sleep when the script is disabled, conserving physics processing.
    }

    private void FixedUpdate()
    {
        velocity.x = direction.x * speed; // Calculate the horizontal component of the velocity based on the defined direction and speed.
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime; // Apply gravity to the vertical component of the velocity.

        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime); // Move the entity's Rigidbody2D to the new position using the calculated velocity.

        if (rigidbody.Raycast(direction, LayerMask.GetMask("Obstacle"))) // Check if there's an obstacle in the entity's movement direction.
        {
            direction = -direction; // If an obstacle is detected, change the movement direction to its opposite.
        }

        if (rigidbody.Raycast(Vector2.down, LayerMask.GetMask("Obstacle"))) // Check if there's an obstacle below the entity.
        {
            velocity.y = Mathf.Max(velocity.y, 0f); // If an obstacle is below, prevent the entity from going through it by zeroing the vertical velocity component.
        }
    }
}
