// This script represents the GameManager responsible for handling game state and logic in a 2D platformer game.

// Import required Unity engine libraries.
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton pattern: a static reference to the GameManager instance, allowing access from other scripts.
    public static GameManager Instance { get; private set; }

    // Variables to track the current game state.
    public int world { get; private set; } // Current world number.
    public int stage { get; private set; } // Current stage number.
    public int lives { get; private set; } // Current number of lives remaining.
    public int cherries { get; private set; } // Current number of collected cherries.

    public Text cherryCountText; // Reference to the UI Text component for displaying cherry count.

    // Awake is called when the script instance is being loaded.
    // Initialize the GameManager singleton, ensuring there is only one instance in the scene.
    private void Awake()
    {
        if (Instance != null)
        {
            // If an instance already exists, destroy this duplicate instance.
            DestroyImmediate(gameObject);
        }
        else
        {
            // If no instance exists, set this as the GameManager instance and don't destroy it on scene changes.
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // OnDestroy is called when the script instance is being destroyed.
    // Reset the GameManager instance when it gets destroyed (e.g., on scene change).
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Start is called before the first frame update.
    private void Start()
    {
        // Start a new game when the GameManager is initialized.
        NewGame();
    }

    // Start a new game by resetting lives and cherries and load the first level.
    private void NewGame()
    {
        lives = 1; // Set the initial number of lives to 1.
        cherries = 0; // Reset the number of collected cherries to 0.

        // Call the UpdateCherryCountText method to update the UI with the initial cherry count (currently disabled).
        // UpdateCherryCountText();

        // Load the first level (world 1, stage 1).
        //LoadLevel(1, 1);
        LoadLevel(1, 0);
    }

    // Load a specific level based on the provided world and stage numbers.
    private void LoadLevel(int world, int stage)
    {
        this.world = world; // Set the current world to the provided world number.
        this.stage = stage; // Set the current stage to the provided stage number.

        // Load the scene corresponding to the given world and stage numbers.
        SceneManager.LoadScene($"{world}-{stage}");
    }

    // Proceed to the next level based on the current world and stage.
    public void NextLevel()
    {
        // Check if the current stage is the last stage of the first world.
        if (world == 1 && stage == 10)
        {
            // If yes, move to the first stage of the next world (world 2, stage 1).
            //LoadLevel(world + 1, 1);
            LoadLevel(1, 0);
        }
        else
        {
            // If not the last stage of the first world, move to the next stage of the same world.
            //LoadLevel(world, stage + 1);
            LoadLevel(1, 0);
        }
    }

    // Reset the current level with a delay (used after the player dies).
    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay); // Invoke the ResetLevel method after the provided delay.
    }

    // Reset the current level (used after the player dies).
    public void ResetLevel()
    {
        lives--; // Decrease the number of lives.

        if (lives > 0)
        {
            // If there are remaining lives, load the current level again.
            //LoadLevel(world, stage);
            LoadLevel(1, 0);
        }
        else
        {
            // If no lives left, end the game (trigger GameOver).
            GameOver();
        }
    }

    // Trigger the Game Over sequence by loading the "GameOverScreen" scene (used when the player loses all lives).
    private void GameOver()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    // Start a new game by loading the first scene of the game (usually the main menu).
    public void StartNewGame()
    {
        SceneManager.LoadScene(0);
    }

    // Increment the cherry count and update the UI text.
    public void AddCherry()
    {
        cherries++; // Increase the cherry count by one.
        UpdateCherryCountText(); // Call the method to update the UI text with the new cherry count.

        // Check if the cherry count is not zero and is a multiple of 50.
        if (cherries != 0 && cherries % 50 == 0)
        {
            AddLife(); // If so, add an extra life to the player.
        }
    }

    // Update the UI text component to display the current cherry count.
    private void UpdateCherryCountText()
    {
        cherryCountText.text = "Points: " + cherries.ToString();
    }

    // Add an extra life to the player.
    public void AddLife()
    {
        lives++; // Increase the number of lives by one.
    }

    // Decrease the number of lives when the player gets hit, and trigger Game Over if there are no lives left.
    public void Hit()
    {
        lives--; // Decrease the number of lives.

        // Check if there are no lives remaining (less than zero).
        if (lives < 0)
        {
            GameOver(); // If no lives left, trigger the Game Over sequence.
        }
    }
}
