using UnityEngine;

public class EnemyB : MonoBehaviour
{
    // Public variables accessible from the Unity Inspector
    public Sprite disappearSprite;     // The sprite displayed when the enemy disappears
    public float disappearingSpeed = 10f;  // The speed at which the enemy disappears

    // Private variables used for internal state
    private bool disappeared;  // A flag indicating whether the enemy has disappeared
    private bool pushed;       // A flag indicating whether the enemy has been pushed

    public GameObject headB;  // Reference to the head game object of the enemy

    // This method is called when a collision occurs with a 2D collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the Player script component from the collided game object
            Player player = collision.gameObject.GetComponent<Player>();

            // Check if the player's legs are above the enemy's head
            if (player.legs.transform.position.y > headB.transform.position.y)
            {
                // If so, make the enemy disappear
                Disappear(this.gameObject);
            }
            else
            {
                // If not, the player hits the enemy
                if (!disappeared)
                {
                    player.Hit();
                }
            }
        }
    }

    // This method is called when a trigger collider is entered
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (disappeared && other.CompareTag("Player"))
        {
            // If the enemy has disappeared and the player collides with it,
            // check if the enemy has been pushed
            if (!pushed)
            {
                // If not, calculate the direction from the player to the enemy
                Vector2 direction = new Vector2(transform.position.x - other.transform.position.x, 0f);

                // Push the enemy in the calculated direction
                PushEnemy(direction);
            }
            else
            {
                // If the enemy has been pushed already, hit the player
                //Player player = other.GetComponent<Player>();
                //player.Hit();
            }
        }
        else if (!disappeared && other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            // If the enemy hasn't disappeared and collides with an object in the "Shell" layer,
            // hit the player
            //Player player = other.GetComponent<Player>();
            //player.Hit();
        }
    }

    // This method makes the enemy disappear
    private void Disappear(GameObject object_)
    {
        disappeared = true;

        // Disable movement and animation components
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;

        // Change the sprite to the disappearing sprite
        GetComponent<SpriteRenderer>().sprite = disappearSprite;

        // Optionally, destroy the enemy game object immediately
        //Destroy(object_, 0f);
    }

    // This method pushes the enemy in a specified direction
    private void PushEnemy(Vector2 direction)
    {
        pushed = true;

        // Enable physics for the enemy
        GetComponent<Rigidbody2D>().isKinematic = false;

        // Configure the movement component with the given direction and speed
        EntityMovement movement = GetComponent<EntityMovement>();
        movement.direction = direction.normalized;
        movement.speed = disappearingSpeed;
        movement.enabled = true;

        // Change the enemy's layer to "PushedEnemy"
        gameObject.layer = LayerMask.NameToLayer("PushedEnemy");
    }

    // This method handles the hit event for the enemy
    private void Hit(GameObject object_)
    {
        // Disable the animated sprite and enable the death animation
        //GetComponent<AnimatedSprite>().enabled = false;
        //GetComponent<DeathAnimation>().enabled = true;

        // Optionally, destroy the enemy game object after a delay
        Destroy(object_, 3f);
    }

    // This method is automatically called when the enemy becomes invisible to the camera
    private void OnBecameInvisible()
    {
        if (pushed)
        {
            // If the enemy was pushed and becomes invisible, destroy it
            Destroy(gameObject);
        }
    }
}
