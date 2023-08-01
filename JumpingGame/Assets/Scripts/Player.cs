using UnityEngine;

// A script that controls the behavior of the player character in the game.
public class Player : MonoBehaviour
{
    // References to the two different sprite renderers for the player.
    public PlayerSpriteRenderer normalRenderer; // Reference to the sprite renderer for the normal state of the player.
    public PlayerSpriteRenderer strongRenderer; // Reference to the sprite renderer for the strong state of the player.

    private DeathAnimation deathAnimation; // Reference to the DeathAnimation component.

    // Properties that allow checking the current state of the player easily.
    public bool strong => strongRenderer.enabled; // Property to check if the player is in the strong state.
    public bool normal => normalRenderer.enabled; // Property to check if the player is in the normal state.
    public bool dead => deathAnimation.enabled; // Property to check if the player is in the dead state.

    public GameObject legs; // Reference to the legs GameObject (not used in the current code snippet).
    public GameManager gameManager; // Reference to the GameManager script (not used in the current code snippet).

    private int coolDown = 100; // A cooldown counter for player actions.

    private void Awake()
    {
        // Initialize the 'deathAnimation' variable by getting the DeathAnimation component from this GameObject.
        deathAnimation = GetComponent<DeathAnimation>();
    }

    public void Update()
    {
        // Decrease the cooldown counter on every update.
        coolDown = coolDown - 1;

        // Output the current cooldown value to the console for debugging purposes.
        Debug.Log(coolDown);
    }

    public void Hit()
    {
        // Check if the cooldown has reached a negative value, meaning the player can perform a hit action.
        if (coolDown < 0)
        {
            Debug.Log("Player has performed a hit!"); // Output a message to the console for debugging purposes.

            // Call the 'Hit()' method in the GameManager script to perform hit-related actions.
            gameManager.Hit();

            // Reset the cooldown to a high value to prevent spamming of hit actions.
            coolDown = 1000;
        }
    }

    private void Shrink()
    {
        // TODO: This method is not implemented yet and should be completed in future development.
    }

    private void Death()
    {
        // Disable the sprite renderers for the normal and strong states.
        normalRenderer.enabled = false;
        strongRenderer.enabled = false;

        // Enable the death animation to play when the player character dies.
        deathAnimation.enabled = true;

        // Call the 'ResetLevel()' method in the GameManager script to restart the level after a delay of 3 seconds.
        GameManager.Instance.ResetLevel(3f);
    }
}
