using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public void PlayAgain()
    {
        // Resets the scores

        // Loads the scene again
		Application.LoadLevel("SampleScene");
    }

    public void Exit()
    {
        // Quits the game
        Application.Quit();
    }
}