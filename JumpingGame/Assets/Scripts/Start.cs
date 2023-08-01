// This script is responsible for handling the start of the game. 
// It is attached to an object in the scene and contains a public method, StartGame(), 
// which will be called when the player initiates the game start process.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    // The StartGame() method is a public function that allows other scripts or UI elements 
    // to initiate the process of loading the next scene in the build index sequence.

    public void StartGame()
    {
        // When StartGame() is called, the SceneManager.GetActiveScene() function is used to retrieve 
        // the currently active scene in the game. Then, using the build index of that scene, 
        // we add 1 to it to determine the next scene in the sequence.

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Finally, SceneManager.LoadScene() is called, passing the calculated nextSceneIndex as a parameter.
        // This will load the scene with the index value equal to the nextSceneIndex, effectively progressing 
        // the player to the next level or stage of the game.

        SceneManager.LoadScene(nextSceneIndex);
    }
}
