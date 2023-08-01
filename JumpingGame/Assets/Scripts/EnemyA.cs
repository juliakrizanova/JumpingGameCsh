using UnityEngine;

public class EnemyA : MonoBehaviour
{
    public Sprite flatSprite; // The sprite used when the enemy is flattened.
    public GameObject head; // Reference to the GameObject representing the enemy's head.

    // This method is called when the enemy collides with another 2D collider.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the collision is with a player object.
        {
            // Note: The following two lines are commented out for debugging purposes and will not be executed.
            //Debug.Log(collision.transform.DotTest(transform, Vector2.down));
            // Get the Player component from the collided player object.
            Player player = collision.gameObject.GetComponent<Player>();

            // Note: The following two lines are commented out for debugging purposes and will not be executed.
            //Debug.Log(player.legs.transform.position.y);
            //Debug.Log(head.transform.position.y);

            // Check if the player's legs are above the enemy's head in the Y-axis.
            if (player.legs.transform.position.y > head.transform.position.y)
            {
                // If the player's legs are above the enemy's head, flatten the enemy.
                Flatten(this.gameObject);
            }
            else
            {
                // If the player's legs are not above the enemy's head, hit the player.
                player.Hit();
            }
        }
    }

    // This method is called when another 2D collider triggers a collision with the enemy.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PushedEnemy"))
        {
            // Note: The following line is commented out, but this function should be called to handle a collision with a "PushedEnemy" layer.
            //Hit(this.gameObject);
        }
    }

    // This method flattens the enemy, disabling certain components and destroying it after a short delay.
    private void Flatten(GameObject object_)
    {
        // Note: The following lines are commented out, but they should disable specific components and change the sprite to the flattened one.
        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<EntityMovement>().enabled = false;
        //GetComponent<AnimatedSprite>().enabled = false;
        //GetComponent<SpriteRenderer>().sprite = flatSprite;

        // Destroy the enemy game object after zero seconds (instantly).
        Destroy(object_, 0f);
    }

    // This method handles the enemy's hit behavior, disabling certain components and destroying it after a short delay.
    private void Hit(GameObject object_)
    {
        // Note: The following lines are commented out, but they should disable specific components and enable a death animation.
        //GetComponent<AnimatedSprite>().enabled = false;
        //GetComponent<DeathAnimation>().enabled = true;

        // Destroy the enemy game object after three seconds to give time for the death animation to play.
        Destroy(object_, 3f);
    }
}
