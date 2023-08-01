// The following code is a script for implementing a side-scrolling camera in a Unity game.

using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player; // Reference to the player's Transform component.

    private void Awake()
    {
        // During the Awake phase of the script's lifecycle, find the player GameObject using its tag "Player"
        // and store its Transform component in the 'player' variable for later use.
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate() // LateUpdate is a built-in Unity function that gets called right before everything renders to the screen.
    {
        // Here, we retrieve the current position of the camera.
        Vector3 cameraPosition = transform.position;

        // To create a smooth side-scrolling effect, we want the camera's X position to always be at least as far as the player's X position.
        // The Mathf.Max function is used to get the maximum value between the current camera X position and the player's X position.
        // This ensures that the camera never moves behind the player and only moves to the right (higher X value) to follow the player.
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);

        // Finally, we update the camera's position with the new calculated position.
        transform.position = cameraPosition;
    }
}
