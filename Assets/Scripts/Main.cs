using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour
{
	int clicks; // A variable for the amount of VALID moves
	int clicksEnemy; // A variable for the amount of VALID moves

	void Start()
	{
		// Initializes the number of clicks to 0
		clicks = 0; // So the player cannot initiate any other GameObject's animation after already choosing one
		clicksEnemy = 0; // So the player cannot initiate any other GameObject's animation after already choosing one

		//// Calculations for a desired screen size
		// Sets the screen's aspect ratio to 20:9
		float targetAspect = 20f / 9f;

		// Calculates the window aspect ratio
		float windowAspect = (float)Screen.width / (float)Screen.height;

		// Scales the height according to the two aspect ratios
		float scaleHeight = windowAspect / targetAspect;

		Camera camera = GetComponent<Camera> ();

		// Setup up the camera accordingly
		if (scaleHeight < 1f)
		{
			Rect rect = camera.rect;

			rect.width = 1f;
			rect.height = scaleHeight;
			rect.x = 0;
			rect.y = (1f - scaleHeight) / 2f;

			camera.rect = rect;
		}
		else
		{
			float scaleWidth = 1f / scaleHeight;

			Rect rect = camera.rect;

			rect.width = scaleWidth;
			rect.height = 1f;
			rect.x = (1f - scaleWidth) / 2f;
			rect.y = 0;

			camera.rect = rect;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("q"))
		{
			GameObject playerBox = GameObject.Find("PaperBox");// Get the clicked GameObject
			print("hey");
			if (playerBox != null && clicks == 0)
			{
				clicks = 1; // The first valid click will make this variable 1

				// Get the animator of the selected GameObject
				Animator animPlayer = playerBox.GetComponent<Animator> ();
				animPlayer.enabled = true; // Play the first animation
                

				// Reloads the scene after the animation is done
				StartCoroutine(ReloadScene());
				ReloadScene ();
			}
		}

		if (Input.GetKeyDown("w"))
        {
			GameObject playerBox = GameObject.Find("RockBox"); // Get the clicked GameObject

            if (playerBox != null && clicks == 0)
            {
                clicks = 1; // The first valid move will make this variable 1

                // Get the animator of the clicked GameObject
                Animator animPlayer = playerBox.GetComponent<Animator>();
                animPlayer.enabled = true; // Play the first animation

                // Reloads the scene after the animation is done
                StartCoroutine(ReloadScene());
                ReloadScene();
            }
        }

		if (Input.GetKeyDown("e"))
        {
			GameObject playerBox = GameObject.Find("ScissorBox"); // Get the clicked GameObject

            if (playerBox != null && clicks == 0)
            {
                clicks = 1; // The first valid click will make this variable 1
                // Get the animator of the clicked GameObject
                Animator animPlayer = playerBox.GetComponent<Animator>();
                animPlayer.enabled = true; // Play the first animation
                

                // Reloads the scene after the animation is done
                StartCoroutine(ReloadScene());
                ReloadScene();
            }
        }


		if (Input.GetKeyDown("i"))
        {
			GameObject playerBox = GameObject.Find("ScissorBox_Enemy");// Get the clicked GameObject
			if (playerBox != null && clicksEnemy == 0)
            {
				print("hey2");
               
				clicksEnemy = 1; // The first valid click will make this variable 1

                // Get the animator of the selected GameObject
                Animator animPlayer = playerBox.GetComponent<Animator>();
                animPlayer.enabled = true; // Play the first animation


                // Reloads the scene after the animation is done
                StartCoroutine(ReloadScene());
                ReloadScene();
            }
        }

        if (Input.GetKeyDown("o"))
        {
			GameObject playerBox = GameObject.Find("RockBox_Enemy"); // Get the clicked GameObject

			if (playerBox != null && clicksEnemy == 0)
            {
				clicksEnemy = 1; // The first valid move will make this variable 1

                // Get the animator of the clicked GameObject
                Animator animPlayer = playerBox.GetComponent<Animator>();
                animPlayer.enabled = true; // Play the first animation

                // Reloads the scene after the animation is done
                StartCoroutine(ReloadScene());
                ReloadScene();
            }
        }

        if (Input.GetKeyDown("p"))
        {
			GameObject playerBox = GameObject.Find("PaperBox_Enemy"); // Get the clicked GameObject

			if (playerBox != null && clicksEnemy == 0)
            {
				clicksEnemy = 1; // The first valid click will make this variable 1
                // Get the animator of the clicked GameObject
                Animator animPlayer = playerBox.GetComponent<Animator>();
                animPlayer.enabled = true; // Play the first animation


                // Reloads the scene after the animation is done
                StartCoroutine(ReloadScene());
                ReloadScene();
            }
        }
	}
    
		
	IEnumerator ReloadScene()
	{
		yield return new WaitForSeconds(3f); // This will wait 5 seconds
		Application.LoadLevel("_MainScene"); // Reload the scene
	}
    
}