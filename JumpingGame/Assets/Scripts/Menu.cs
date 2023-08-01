// This script is responsible for handling the main menu functionality.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // This method is called when the "Start Game" button is clicked in the main menu.
    // It loads the scene with the index 1, which represents the first level of the game.

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
