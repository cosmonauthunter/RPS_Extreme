using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalLeaderboard : MonoBehaviour {

    [SerializeField]
    GameObject entryPrefab;

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

    void ShowLeaderboard() {

        entries.Sort((a, b) => b.score.CompareTo(a.score));

        float counter = 0;
        foreach (LeaderboardEntry entry in entries) {
            GameObject temp = Instantiate(entryPrefab);
            temp.transform.SetParent(GameObject.Find("LeaderbordCanvas").transform);
            temp.transform.localScale = new Vector3(1, 1, 1);
            temp.transform.Find("Name").GetComponent<Text>().text = entry.playerName;
            temp.transform.Find("Score").GetComponent<Text>().text = entry.score.ToString();
            temp.transform.position = new Vector3(0, 2.7f - 1.2f * counter, 0);
            counter++;
        }
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
