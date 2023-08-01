using UnityEngine;
using System.Collections;

public class DeathAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component.
    public Sprite deadSprite; // The sprite to be displayed when the entity dies.

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Automatically gets the SpriteRenderer component if not set manually.
    }

    private void OnEnable()
    {
        UpdateSprite(); // Sets up the sprite and sorting order for the death animation.
        DisablePhysics(); // Disables physics components and movement scripts for the entity.
        StartCoroutine(Animate()); // Starts the animation coroutine to make the entity "jump" and disappear.
    }

    // Updates the sprite and sorting order for the death animation.
    private void UpdateSprite()
    {
        spriteRenderer.enabled = true; // Makes sure the SpriteRenderer is enabled before displaying the dead sprite.
        spriteRenderer.sortingOrder = 20; // Sets the sorting order to ensure the sprite is displayed above other elements.

        if (deadSprite != null)
        {
            spriteRenderer.sprite = deadSprite; // Sets the dead sprite if it is provided.
        }
    }

    // Disables physics components and movement scripts for the entity during the death animation.
    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>(); // Gets all Collider2D components attached to the entity.

        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false; // Disables each collider to prevent collisions during the animation.
        }

        GetComponent<Rigidbody2D>().isKinematic = true; // Makes the entity's Rigidbody2D unaffected by forces during the animation.

        PlayerMovement playerMovement = GetComponent<PlayerMovement>(); // Gets the PlayerMovement script attached to the entity.
        EntityMovement entityMovement = GetComponent<EntityMovement>(); // Gets the EntityMovement script attached to the entity.

        if (playerMovement != null)
        {
            playerMovement.enabled = false; // Disables the PlayerMovement script if it exists, stopping player-controlled movement.
        }

        if (entityMovement != null)
        {
            entityMovement.enabled = false; // Disables the EntityMovement script if it exists, stopping any AI-controlled movement.
        }
    }

    // Coroutine that animates the death of the entity by making it "jump" and disappear over time.
    private IEnumerator Animate()
    {
        float elapsed = 0f; // Keeps track of the elapsed time during the animation.
        float duration = 3f; // The total duration of the death animation.

        float jumpVelocity = 10f; // The initial upward velocity applied to the entity.
        float gravity = -36f; // The gravitational force applied to the entity during the animation.

        Vector3 velocity = Vector3.up * jumpVelocity; // The initial velocity vector with an upward component.

        // Loop that runs during the duration of the animation.
        while (elapsed < duration)
        {
            transform.position += velocity * Time.deltaTime; // Moves the entity based on its velocity.
            velocity.y += gravity * Time.deltaTime; // Applies gravity to the entity, simulating a "jump" motion.
            elapsed += Time.deltaTime; // Updates the elapsed time.
            yield return null; // Yields to the next frame to continue the animation in the next frame.
        }
    }
}
