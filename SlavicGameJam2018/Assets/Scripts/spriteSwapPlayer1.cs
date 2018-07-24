using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;




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

	GameObject PEffectRef;
	GameObject REffectRef;
	GameObject SEffectRef;

	public float Magnitude = 10f;
    public float Roughness = 10f;
    public float FadeOutTime = 5f;

	private void Start()
	{
		PEffectRef = GameObject.Find("/MainGameflow/Canvas/Cards/PlayerOneCard/PEffectMesh");
		REffectRef = GameObject.Find("/MainGameflow/Canvas/Cards/PlayerOneCard/REffectMesh");
		SEffectRef = GameObject.Find("/MainGameflow/Canvas/Cards/PlayerOneCard/SEffectMesh");
	}

	public void SwapSprite()
    {
		GameController.choice playersChoice1 = GameObject.Find("GameController").GetComponent<GameController>().player1.choice;

		if (playersChoice1 == GameController.choice.paper)
		{
			this.GetComponent<SpriteRenderer>().sprite = cardPapper;

            //effects
			PEffectRef.SetActive(true);
			REffectRef.SetActive(false);
            SEffectRef.SetActive(false);

		}
		if (playersChoice1 == GameController.choice.rock)
        {
            this.GetComponent<SpriteRenderer>().sprite = cardRock;

			//effects
			REffectRef.SetActive(true);
			PEffectRef.SetActive(false);
			SEffectRef.SetActive(false);


        }
		if (playersChoice1 == GameController.choice.scissors)
		{
			this.GetComponent<SpriteRenderer>().sprite = cardScissors;

			//effects
			SEffectRef.SetActive(true);
			PEffectRef.SetActive(false);
            REffectRef.SetActive(false);
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
    

	public void ShakeThatCamera()
	{
		
		CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, 0, FadeOutTime);
	}

}

