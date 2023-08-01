using UnityEngine;

// This script is attached to an object in the game that represents a death zone, and it is responsible for handling the player's death when they fall into it.

public class PlayerFallDeath : MonoBehaviour
{
    // This method is triggered when a 2D collider attached to the object enters a collision with another collider marked as a "trigger."

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider's GameObject is tagged as "Player." If it is, then it means the player has fallen into the death zone.

        if (other.CompareTag("Player"))
        {
            // Disable the GameObject associated with the "Player" collider. This will visually hide the player and prevent any further interaction with it.

            other.gameObject.SetActive(false);

            // Access the GameManager.Instance (a singleton) to call its ResetLevel method with a delay of 3 seconds (3f) to reset the level and respawn the player.

            GameManager.Instance.ResetLevel(3f);
        }
        else
        {
            // If the collider's GameObject is not tagged as "Player" (i.e., any other object collides with this trigger), then simply destroy the other GameObject.

            Destroy(other.gameObject);
        }
    }
}
