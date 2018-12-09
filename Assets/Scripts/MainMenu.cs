using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Player player;
    public Text scoreLabel;
    public GameObject leaderboard;
    public int highscore;

    public void StartGame()
    {
        player.StartGame();
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame(float distanceTraveled)
    {
        highscore = ((int)(distanceTraveled));       
        gameObject.SetActive(true);

        if (highscore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", highscore);
            scoreLabel.text = "High Score: " + highscore.ToString();
            
        }

    }

    // Use this for initialization
    void Start ()
    {
        scoreLabel.text = "High Score: " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
