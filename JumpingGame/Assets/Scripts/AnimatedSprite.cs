using UnityEngine;

// The AnimatedSprite class is responsible for playing a sequence of sprites at a specified frame rate.
public class AnimatedSprite : MonoBehaviour
{
    // An array of Sprites that represents the frames of the animation.
    public Sprite[] sprites;

    // The frame rate at which the animation plays (measured in frames per second).
    // The default value is set to 1/6th of a second (6 frames per second).
    public float framerate = 1f / 6f;

    // A reference to the SpriteRenderer component attached to the GameObject.
    // This component is used to change the sprite displayed on the GameObject.
    private SpriteRenderer spriteRenderer;

    // The current frame index of the animation.
    private int frame;

    // This method is called when the GameObject is instantiated (awakened).
    // It retrieves the SpriteRenderer component and assigns it to the spriteRenderer variable.
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // This method is called when the GameObject becomes enabled or active.
    // It sets up the animation by invoking the Animate method repeatedly based on the framerate.
    private void OnEnable()
    {
        // InvokeRepeating schedules the Animate method to be called repeatedly after a specified initial delay (framerate),
        // and then repeatedly at the same rate (framerate).
        InvokeRepeating(nameof(Animate), framerate, framerate);
    }

    // This method is called when the GameObject becomes disabled or inactive.
    // It cancels any ongoing InvokeRepeating calls to stop the animation.
    private void OnDisable()
    {
        CancelInvoke();
    }

    // The core method responsible for animating the sprite sequence.
    // This method is called by the InvokeRepeating function at the defined framerate.
    private void Animate()
    {
        // Increment the frame index to move to the next frame.
        frame++;

        // If the frame index exceeds the number of sprites in the array,
        // wrap the animation back to the first frame (loop the animation).
        if (frame >= sprites.Length)
        {
            frame = 0;
        }

        // Ensure the frame index is within the valid range (0 to sprites.Length - 1),
        // then update the SpriteRenderer's sprite to display the current frame.
        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }
    }
}
