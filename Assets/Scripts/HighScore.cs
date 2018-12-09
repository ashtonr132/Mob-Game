using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text[] highscore;
    public Text[] highscorename;
    public int CurrentNum = 0;
    public float number;
    public int num;
    public InputField playertext;
    public string playername;
    int playerscore;
    public MainMenu mainMenu;
    public Player player;

    // Use this for initialization
    void Start ()
    {
        gameObject.SetActive(false);

        for (int i = 0; i < 6; i++)
        {
            highscore[i].text = PlayerPrefs.GetFloat("highscore" + i, 0).ToString();
            //highscorename[i].text = PlayerPrefs.GetString("highscorename" + i);

        }

        //playername = playertext.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScore(playerscore);
        if (Input.GetKeyDown("up"))
        {
            for (int i = 0; i < 6; i++)
            {
                number = playerscore;
                highscore[i].text = number.ToString();
                PlayerPrefs.SetFloat("highscore" + i, number);
                PlayerPrefs.SetString("highscorename" + i, playername);
            }

        }

    }

    public void PlayerScore(float distanceTraveled)
    {
        mainMenu.EndGame(distanceTraveled);
        playerscore = ((int)(distanceTraveled));
    }


    public void PlayerName()
    {

    }
}
