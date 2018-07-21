using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float hp { get; set; }
    public float cardSwitches { get; set; }
    public float hpMax { get; set; }

    public GameController.choice choice { get; set; }



	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Player() {
        hp = hpMax = 6;
        cardSwitches = 10;
    }

    public void SwitchToRock() {
        cardSwitches -= 1;
        choice = GameController.choice.rock;
    }
    public void SwitchToPaper() {
        cardSwitches -= 1;
        choice = GameController.choice.paper;
    }
    public void SwitchToScissors() {
        cardSwitches -= 1;
        choice = GameController.choice.scissors;
    }


}
