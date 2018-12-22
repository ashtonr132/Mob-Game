using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Player player;
    public Text currScoreT, highScoreT, totalScoreT;
    public static int highScore, totalScore, currScore;

    public void StartGame()
    {
        player.StartGame();
        foreach (Transform item in transform)
        {
            gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame(float distanceTraveled)
    {
        foreach (Transform item in transform)
        {
            gameObject.SetActive(true);
        }
        if (highScore < currScore)
        {
            highScore = currScore;
        }
            SaveLoad.Save(highScore, (totalScore + currScore));

        currScore = 0;
    }

    // Use this for initialization
    void Start ()
    {
        SaveLoad.Load();
    }

    private void Update()
    {
        if (highScore > currScore)
        {
            highScoreT.text = "High Score: " + highScore.ToString();

        }
        else
        {
            highScoreT.text = "High Score: " + currScore.ToString();
        }
        totalScoreT.text = "Total Score: " + (totalScore + currScore).ToString();
        currScoreT.text = "Current Score: " + currScore.ToString();

    }
}
