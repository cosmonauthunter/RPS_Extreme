using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSwapPlayer2 : MonoBehaviour
{


	[SerializeField]
	Sprite cardPapper;
	[SerializeField]
	Sprite cardRock;
	[SerializeField]
	Sprite cardScissors;
	[SerializeField]
    Sprite cardDefault;



	public void SwapSprite()
	{
		GameController.choice playersChoice2 = GameObject.Find("GameController").GetComponent<GameController>().player2.choice;

		if (playersChoice2 == GameController.choice.paper)
		{
			this.GetComponent<SpriteRenderer>().sprite = cardPapper;
		}

		if (playersChoice2 == GameController.choice.rock)
		{
			this.GetComponent<SpriteRenderer>().sprite = cardRock;
		}

		if (playersChoice2 == GameController.choice.scissors)
		{
			this.GetComponent<SpriteRenderer>().sprite = cardScissors;
		}

	}

	public void SwapToDefault()
	{
		this.GetComponent<SpriteRenderer>().sprite = cardDefault;
	}


	public void DisableSelf()
	{
		Animator animPlayer = this.GetComponent<Animator>();
		animPlayer.enabled = false; // Play the first animation	}
	}


    public void PlaySwapSound() {
        GetComponent<AudioSource>().Play();
    }


    public void PlayOutcomeAnimation()
    {

        //Instantiate(boomEffect);
        //anim.CrossFade(animName, 0f); // Play animation

        //// Depending on the case, play the appropriate animation and destroy the appropriate GameObjects
        //if (result == "Lost")
        //{

        //}
        //else if (result == "Win")
        //{

        //}
        //else if (result == "Tie")
        //{

        //}
    }

}