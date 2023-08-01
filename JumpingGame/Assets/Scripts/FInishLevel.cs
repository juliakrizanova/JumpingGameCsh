// Import Unity Engine library for accessing Unity functionalities.
using UnityEngine;
// Import Unity SceneManager library for scene management operations.
using UnityEngine.SceneManagement;

// Define the class 'FinishLevel' that inherits from MonoBehaviour.
public class FInishLevel : MonoBehaviour
{
    // Public variable to hold a reference to the GameObject representing the winner screen UI.
    public GameObject WinnerScreen;

    // This method is called when the GameObject with a 2D Collider enters a trigger.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding GameObject has the "Player" tag assigned to it.
        if (other.gameObject.tag == "Player")
        {
            // If the condition is true, load the scene with index 2, representing the next level.
            SceneManager.LoadScene(2);
        }
    }

    // This method is used to start the game by loading the scene with index 1 (presumably the main menu).
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // This private method is responsible for showing the winner screen UI and pausing the game.
    private void ShowWinnerScreen()
    {
        // Activate the winner screen GameObject to display the victory UI.
        WinnerScreen.SetActive(true);

        // Pause the game by setting the time scale to 0, which freezes all in-game processes.
        Time.timeScale = 0f;
    }

    // This public method is used to close the winner screen UI and resume the game.
    public void CloseWinnerScreen()
    {
        // Deactivate the winner screen GameObject, making it disappear from the UI.
        WinnerScreen.SetActive(false);

        // Resume the game by setting the time scale back to 1, allowing in-game processes to continue.
        Time.timeScale = 1f;
    }

    // This public method is used to quit the application when called.
    public void Quit()
    {
        // Exit the application entirely, terminating the game.
        Application.Quit();
    }
}
