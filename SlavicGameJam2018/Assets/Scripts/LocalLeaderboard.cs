using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalLeaderboard : MonoBehaviour {

    public class LeaderboardEntry {

        public string playerName { get; set; }
        public float score { get; set; }

        public LeaderboardEntry(string name) {

            playerName = name;
            score = 0;

        }
    }

    List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

    public void playerWon(string playerName) {
        LeaderboardEntry referencedPlayer = entries.Find(entry => entry.playerName == playerName);
        if (referencedPlayer != null) {
            referencedPlayer.score += 2;
        }
        else {
            LeaderboardEntry newPlayer = new LeaderboardEntry(playerName);
            newPlayer.score += 2;
            entries.Add(newPlayer);
        }
    }

    public void playerLost(string playerName) {
        LeaderboardEntry referencedPlayer = entries.Find(entry => entry.playerName == playerName);
        if (referencedPlayer != null) {
            referencedPlayer.score -= 1;
        }
        else {
            LeaderboardEntry newPlayer = new LeaderboardEntry(playerName);
            newPlayer.score -= 1;
            entries.Add(newPlayer);
        }
    }

    public void AddNewPlayer(string newPlayerName) {
        LeaderboardEntry referencedPlayer = entries.Find(entry => entry.playerName == newPlayerName);
        if (referencedPlayer != null) {
            //TODO Username already exists
        }
        else {
            LeaderboardEntry newPlayer = new LeaderboardEntry(newPlayerName);
            entries.Add(newPlayer);
        }
    }

    // Use this for initialization
    void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
