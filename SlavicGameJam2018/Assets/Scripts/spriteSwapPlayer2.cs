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

	GameObject PEffectRef;
    GameObject REffectRef;
    GameObject SEffectRef;

	private void Start()
    {
        PEffectRef = GameObject.Find("/MainGameflow/Canvas/Cards/PlayerTwoCard/PEffectMesh");
		REffectRef = GameObject.Find("/MainGameflow/Canvas/Cards/PlayerTwoCard/REffectMesh");
		SEffectRef = GameObject.Find("/MainGameflow/Canvas/Cards/PlayerTwoCard/SEffectMesh");
    }

	public void SwapSprite()
	{
		GameController.choice playersChoice2 = GameObject.Find("GameController").GetComponent<GameController>().player2.choice;

		if (playersChoice2 == GameController.choice.paper)
		{
			this.GetComponent<SpriteRenderer>().sprite = cardPapper;

			//effects
            PEffectRef.SetActive(true);
            REffectRef.SetActive(false);
            SEffectRef.SetActive(false);
		}

		if (playersChoice2 == GameController.choice.rock)
		{
			this.GetComponent<SpriteRenderer>().sprite = cardRock;

			//effects
            REffectRef.SetActive(true);
            PEffectRef.SetActive(false);
            SEffectRef.SetActive(false);
		}

		if (playersChoice2 == GameController.choice.scissors)
		{
			this.GetComponent<SpriteRenderer>().sprite = cardScissors;

			//effects
            SEffectRef.SetActive(true);
            PEffectRef.SetActive(false);
            REffectRef.SetActive(false);
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