using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) {
            GameObject.Find("GameController").GetComponent<GameController>().RestartGame();
        };	
	}
}
