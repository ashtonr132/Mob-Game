using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Player player;
    public Text scoreLabel;
    public GameObject leaderboard;
    public static int highScore, totalScore;
    internal Vector2 scr;

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
        if (distanceTraveled > highScore)
        {
            highScore = ((int)(distanceTraveled));
        }
        totalScore += (int)distanceTraveled;
        gameObject.SetActive(true);
        SaveLoad.Save(new Vector2(highScore, totalScore));
    }

    // Use this for initialization
    void Start ()
    {
        SaveLoad.Load();
        scoreLabel.text = "High Score: " + highScore.ToString();
    }
}
