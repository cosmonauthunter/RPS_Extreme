using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSwapPlayer1 : MonoBehaviour {

	[SerializeField]
	GameObject boomEffect;
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
		GameController.choice playersChoice1 = GameObject.Find("GameController").GetComponent<GameController>().player1.choice;

		if (playersChoice1 == GameController.choice.paper)
		{
			this.GetComponent<SpriteRenderer>().sprite = cardPapper;
		}

		if (playersChoice1 == GameController.choice.rock)
        {
            this.GetComponent<SpriteRenderer>().sprite = cardRock;
        }

		if (playersChoice1 == GameController.choice.scissors)
        {
			this.GetComponent<SpriteRenderer>().sprite = cardScissors;
        }

    }


	public void DisableSelf()
    {
        Animator animPlayer = this.GetComponent<Animator>();
        animPlayer.enabled = false; // stop the first animation }
    }


	public void SwapToDefault()
    {
        this.GetComponent<SpriteRenderer>().sprite = cardDefault;
    }

   
	public void PlayOutcomeAnimation()
    {

		Instantiate(boomEffect);

    }

    public void PlaySwapSound() {
        GetComponent<AudioSource>().Play();
    }
    
}
