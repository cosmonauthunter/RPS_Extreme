using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    [SerializeField]
    float initialCountdownTime;
    float elapsedTime = -1;
 
	[SerializeField]
	RectTransform timeGauge;

    [SerializeField]
    RectTransform player1HPBar;
    [SerializeField]
    RectTransform player2HPBar;

	[SerializeField]
	RectTransform player1MPBar;
	[SerializeField]
	RectTransform player2MPBar;

    [SerializeField]
    SpriteRenderer player1CardSprite;
    [SerializeField]
    SpriteRenderer player2CardSprite;



    float initialGaugeSize;

    public enum choice { none, rock, paper, scissors };
    bool inputAllowed = true;
 
    public Player player1 { get; set; }
    public Player player2 { get; set; }

    //transition
    Vector3 vel1, vel2, desScale1, desScale2;
    
    // Use this for initialization
    void Start() {
        player1 = new Player();
        player2 = new Player();
        elapsedTime = initialCountdownTime;
		initialGaugeSize = 1;
        vel1 = vel2 = Vector3.zero;
		desScale1 = desScale2 = timeGauge.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update() {

        print(inputAllowed);

        if (inputAllowed) {
            if (player1.cardSwitches > 0) {
                if (Input.GetKeyDown("q")) {
					player1.SwitchToRock();
                    player1CardSprite.GetComponent<Animator>().enabled = true; // Play the first animation
                }
                if (Input.GetKeyDown("w")) {
                    player1.SwitchToPaper();
				    player1CardSprite.GetComponent<Animator>().enabled = true; // Play the first animation

                }
                if (Input.GetKeyDown("e")) {
                    player1.SwitchToScissors();
					player1CardSprite.GetComponent<Animator>().enabled = true; // Play the first animation
                }
            }
            if (player2.cardSwitches > 0) {
                if (Input.GetKeyDown("i")) {
                    player2.SwitchToRock();
            		player2CardSprite.GetComponent<Animator>().enabled = true; // Play the first animation
                }
                if (Input.GetKeyDown("o")) {
                    player2.SwitchToPaper();
                 	player2CardSprite.GetComponent<Animator>().enabled = true; // Play the first animation


                }
                if (Input.GetKeyDown("p")) {
                    player2.SwitchToScissors();
					player2CardSprite.GetComponent<Animator>().enabled = true; // Play the first animation
                }
            }
        }

        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0) {
            inputAllowed = false;

            Clash();
            //THIS IS WHERE ALL THE MEAT HAPPENS

            initialCountdownTime *= 0.8f;
            elapsedTime = initialCountdownTime;
            //Timer resets...
        }
        
		timeGauge.localScale = new Vector3(initialGaugeSize * elapsedTime / initialCountdownTime, 1, 1);

        player1HPBar.localScale = Vector3.SmoothDamp(player1HPBar.localScale, desScale1, ref vel1, 0.5f);
        player2HPBar.localScale = Vector3.SmoothDamp(player2HPBar.localScale, desScale2, ref vel2, 0.5f);

		player1MPBar.localScale = new Vector3(player1.cardSwitches / player1.cardSwitchesMax, 1, 1);      
		player2MPBar.localScale = new Vector3(player2.cardSwitches / player2.cardSwitchesMax, 1, 1);

    }

    void Clash() {

        if (player1.choice == choice.none && player2.choice == choice.none) {
            PlayerTie();
        }
        if (player1.choice == choice.none && player2.choice != choice.none) {
            PlayerOneGetHit();
        }
        if (player2.choice == choice.none && player1.choice != choice.none) {
            PlayerTwoGetHit();
        }
        if (player1.choice == choice.rock) {
            if (player2.choice == choice.rock) { PlayerTie(); }
            if (player2.choice == choice.paper) { PlayerOneGetHit(); }
            if (player2.choice == choice.scissors) { PlayerTwoGetHit(); }
        }
        if (player1.choice == choice.paper) {
            if (player2.choice == choice.rock) { PlayerTwoGetHit(); }
            if (player2.choice == choice.paper) { PlayerTie(); }
            if (player2.choice == choice.scissors) { PlayerOneGetHit(); }
        }
        if (player1.choice == choice.scissors) {
            if (player2.choice == choice.rock) { PlayerOneGetHit(); }
            if (player2.choice == choice.paper) { PlayerTwoGetHit(); }
            if (player2.choice == choice.scissors) { PlayerTie(); }
        }
    }

    void PlayerTwoGetHit() {
        player2.hp -= 1;
        if (player2.hp==0) {
            PlayerOneWin();
        }
        desScale2 = new Vector3(player2.hp / player2.hpMax, 1,1);
        inputAllowed = true;
    }
    void PlayerOneGetHit() {
        player1.hp -= 1;
        if (player1.hp == 0) {
            PlayerTwoWin();
        }
        desScale1 = new Vector3(player1.hp / player1.hpMax, 1,1);
        inputAllowed = true;
    }
    void PlayerTie() {
        inputAllowed = true;
    }

    void PlayerOneWin() {

    }
    void PlayerTwoWin() {

    }
    void GameTie() {

    }

}
