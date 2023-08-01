using System.Collections;
using UnityEngine;

// A script class to manage point collection for the player.
public class CollectPoints : MonoBehaviour
{
    // An enumeration to define different types of collectible items.
    // Only one type, Cherry, is defined for now.
    public enum Type
    {
        Cherry,
    }

    // Public variable to specify the type of the collectible item for this instance.
    public Type type;

    // This method is triggered when the Collider2D component of this object collides with another collider.
    // Specifically, it checks if the collision is with a GameObject that has the tag "Player".
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the "Collect" method and pass the GameObject of the colliding player as an argument.
            Collect(other.gameObject);
        }
    }

    // A private method responsible for handling the collection of points/items.
    private void Collect(GameObject player)
    {
        // A switch statement to determine the action based on the "type" of the collectible item.
        switch (type)
        {
            // If the item type is "Cherry," increment the cherry count using the GameManager.Instance.
            case Type.Cherry:
                GameManager.Instance.AddCherry();
                break;
        }

        // After processing the collection, destroy the current collectible object.
        // This ensures that the player cannot collect the same item again.
        Destroy(gameObject);
    }
}
