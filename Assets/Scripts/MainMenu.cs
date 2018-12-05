using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Player player;
    public GameObject menuCam;
    public GameObject shopCanvas;
    public Text scoreLabel, hsLabel;
    internal int highScore, totalScore;

    private void Awake()
    {
        GetComponent<SaveLoad>().Load();
    }
    public void StartGame()
    {
        player.StartGame();
        gameObject.SetActive(false);
        menuCam.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame(float distanceTraveled)
    {
        if ((int)(distanceTraveled) > highScore)
        {
            highScore = (int)(distanceTraveled);
        }
        gameObject.SetActive(true);
        totalScore += (int)(distanceTraveled);
        scoreLabel.text = "Total Score: " + totalScore.ToString();
        hsLabel.text = "High Score: " + highScore.ToString();
        GetComponent<SaveLoad>().Save(new Vector2(highScore, totalScore));
    }

    public void OpenShop()
    {
        shopCanvas.SetActive(true);
    }

    public void CloseShop()
    {
        shopCanvas.SetActive(false);
    }
}
