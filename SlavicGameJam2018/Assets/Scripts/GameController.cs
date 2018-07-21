using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    [SerializeField]
    float countdownTime;
    float elapsedTime = -1;
    [SerializeField]
    Text timerClock;

	[SerializeField]
	RectTransform UITimeGauge;

    [SerializeField]
    RectTransform PlayerOneHealthBar;
    [SerializeField]
    RectTransform PlayerTwoHealthBar;

	[SerializeField]
	RectTransform PlayerOnePowerBar;
	[SerializeField]
	RectTransform PlayerTwoPowerBar;

    [SerializeField]
    Text PlayerOneSwitches;
    [SerializeField]
    Text PlayerTwoSwitches;

    [SerializeField]
    SpriteRenderer PlayerOneCard;
    [SerializeField]
    SpriteRenderer PlayerTwoCard;



    float initialGaugeSize;

    public enum choice { none, rock, paper, scissors };
    bool inputAllowed = true;
 
    public Player PlayerOne { get; set; }
    public Player PlayerTwo { get; set; }

    //transition
    Vector3 vel1, vel2, desScale1, desScale2;
    
    // Use this for initialization
    void Start() {
        PlayerOne = new Player();
        PlayerTwo = new Player();
        elapsedTime = countdownTime;
		initialGaugeSize = 1;
        vel1 = vel2 = Vector3.zero;
		desScale1 = desScale2 = UITimeGauge.localScale = new Vector3(1, 1, 1);
        PlayerOneSwitches.text = PlayerOne.cardSwitches.ToString();
        PlayerTwoSwitches.text = PlayerTwo.cardSwitches.ToString();
    }

    // Update is called once per frame
    void Update() {

        print(inputAllowed);

        if (inputAllowed) {
            if (PlayerOne.cardSwitches > 0) {
                if (Input.GetKeyDown("q")) {
					PlayerOne.SwitchToRock();
                    PlayerOneSwitches.text = PlayerOne.cardSwitches.ToString();


					// Get the animator of the clicked GameObject
                    Animator animPlayer = PlayerOneCard.GetComponent<Animator>();
                    animPlayer.enabled = true; // Play the first animation
                }
                if (Input.GetKeyDown("w")) {
                    PlayerOne.SwitchToPaper();
					PlayerOneSwitches.text = PlayerOne.cardSwitches.ToString();

					// Get the animator of the clicked GameObject
					Animator animPlayer = PlayerOneCard.GetComponent<Animator>();
                    animPlayer.enabled = true; // Play the first animation

                }
                if (Input.GetKeyDown("e")) {
                    PlayerOne.SwitchToScissors();
					PlayerOneSwitches.text = PlayerOne.cardSwitches.ToString();

					// Get the animator of the clicked GameObject
					Animator animPlayer = PlayerOneCard.GetComponent<Animator>();
                    animPlayer.enabled = true; // Play the first animation
                }
            }
            if (PlayerTwo.cardSwitches > 0) {
                if (Input.GetKeyDown("i")) {
                    PlayerTwo.SwitchToRock();
                    PlayerTwoSwitches.text = PlayerTwo.cardSwitches.ToString();

					// Get the animator of the clicked GameObject
					Animator animPlayer = PlayerTwoCard.GetComponent<Animator>();
                    animPlayer.enabled = true; // Play the first animation
                }
                if (Input.GetKeyDown("o")) {
                    PlayerTwo.SwitchToPaper();
                    PlayerTwoSwitches.text = PlayerTwo.cardSwitches.ToString();

					// Get the animator of the clicked GameObject
					Animator animPlayer = PlayerTwoCard.GetComponent<Animator>();
                    animPlayer.enabled = true; // Play the first animation


                }
                if (Input.GetKeyDown("p")) {
                    PlayerTwo.SwitchToScissors();
                    PlayerTwoSwitches.text = PlayerTwo.cardSwitches.ToString();

					// Get the animator of the clicked GameObject
					Animator animPlayer = PlayerTwoCard.GetComponent<Animator>();
                    animPlayer.enabled = true; // Play the first animation
                }
            }
        }

        elapsedTime -= Time.deltaTime;
        timerClock.text = elapsedTime.ToString();

        if (elapsedTime <= 0) {
            inputAllowed = false;

            Clash();
            //THIS IS WHERE ALL THE MEAT HAPPENS

            elapsedTime = countdownTime;
            //Timer resets...
        }


		UITimeGauge.localScale = new Vector3(initialGaugeSize * elapsedTime / countdownTime, 1, 1);

        PlayerOneHealthBar.localScale = Vector3.SmoothDamp(PlayerOneHealthBar.localScale, desScale1, ref vel1, 0.5f);
        PlayerTwoHealthBar.localScale = Vector3.SmoothDamp(PlayerTwoHealthBar.localScale, desScale2, ref vel2, 0.5f);

		PlayerOnePowerBar.localScale = new Vector3(PlayerOne.cardSwitches / PlayerOne.cardSwitchesMax, 1, 1);      
		PlayerTwoPowerBar.localScale = new Vector3(PlayerTwo.cardSwitches / PlayerTwo.cardSwitchesMax, 1, 1);

    }

    void Clash() {

        if (PlayerOne.choice == choice.none && PlayerTwo.choice == choice.none) {
            PlayerTie();
        }
        if (PlayerOne.choice == choice.none && PlayerTwo.choice != choice.none) {
            PlayerOneGetHit();
        }
        if (PlayerTwo.choice == choice.none && PlayerOne.choice != choice.none) {
            PlayerTwoGetHit();
        }
        if (PlayerOne.choice == choice.rock) {
            if (PlayerTwo.choice == choice.rock) { PlayerTie(); }
            if (PlayerTwo.choice == choice.paper) { PlayerOneGetHit(); }
            if (PlayerTwo.choice == choice.scissors) { PlayerTwoGetHit(); }
        }
        if (PlayerOne.choice == choice.paper) {
            if (PlayerTwo.choice == choice.rock) { PlayerTwoGetHit(); }
            if (PlayerTwo.choice == choice.paper) { PlayerTie(); }
            if (PlayerTwo.choice == choice.scissors) { PlayerOneGetHit(); }
        }
        if (PlayerOne.choice == choice.scissors) {
            if (PlayerTwo.choice == choice.rock) { PlayerOneGetHit(); }
            if (PlayerTwo.choice == choice.paper) { PlayerTwoGetHit(); }
            if (PlayerTwo.choice == choice.scissors) { PlayerTie(); }
        }
    }

    void PlayerTwoGetHit() {
        print("Player one won the round");
        PlayerTwo.hp -= 1;
        if (PlayerTwo.hp==0) {
            PlayerOneWin();
        }
        desScale2 = new Vector3(PlayerTwo.hp / PlayerTwo.hpMax, 1,1);
        inputAllowed = true;
    }
    void PlayerOneGetHit() {
        print("Player two won the round");
        PlayerOne.hp -= 1;
        if (PlayerOne.hp == 0) {
            PlayerTwoWin();
        }
        desScale1 = new Vector3(PlayerOne.hp / PlayerOne.hpMax, 1,1);
        inputAllowed = true;
    }
    void PlayerTie() {
        print("It's a tie");
        inputAllowed = true;
    }

    void PlayerOneWin() {

    }
    void PlayerTwoWin() {

    }
    void GameTie() {

    }

}
