using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component attached to this GameObject.
    private PlayerMovement movement;  // Reference to the PlayerMovement component attached to this GameObject.

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Assign the SpriteRenderer component attached to this GameObject to the spriteRenderer variable.
        movement = GetComponent<PlayerMovement>();  // Assign the PlayerMovement component attached to this GameObject to the movement variable.
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;  // Enable the visibility of the spriteRenderer component, making the player sprite visible.
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;  // Disable the visibility of the spriteRenderer component, making the player sprite invisible.
    }
}
