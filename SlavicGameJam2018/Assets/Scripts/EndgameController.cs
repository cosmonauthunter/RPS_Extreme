using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.Return)) || (Input.GetKeyDown(KeyCode.Space)) ) {
            GameObject.Find("GameController").GetComponent<GameController>().RestartGame();
        };	
	}
}
