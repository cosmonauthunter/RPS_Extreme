using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSwapPlayer1 : MonoBehaviour {


	[SerializeField]
    Sprite cardPapper;
    [SerializeField]
    Sprite cardRock;
    [SerializeField]
    Sprite cardScissors;


	public void SwapSprite()
    {
		GameController.choice playersChoice1 = GameObject.Find("GameController").GetComponent<GameController>().PlayerOne.choice;

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
        animPlayer.enabled = false; // Play the first animation }
    }
}
