using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Player player;
    public GameObject menuCam;
    public GameObject shopCanvas;
    public Text scoreLabel;
    public static int totalScore, highScore;

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
        scoreLabel.text = "High Score: " + ((int)(distanceTraveled)).ToString();
        gameObject.SetActive(true);
    }

    public void OpenShop()
    {
        shopCanvas.SetActive(true);
    }

    public void CloseShop()
    {
        shopCanvas.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
