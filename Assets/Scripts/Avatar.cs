using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour {

    public ParticleSystem.EmissionModule trail;
    public float deathCountdown = -1f;
    public float speedtimer = 0f;
    public float slowtimer = 0f;
    public float destroytimer = 0f;
    private Player player;
    public GameObject Shield;
    public GameObject Timermachine;
    public GameObject Burners;
    public GameObject engine;
    public bool speedtimerstart = false;
    public bool slowtimerstart = false;
    public float num = 0f;
    public bool DestroyerMode = false;

    private void Awake()
    {
        player = transform.root.GetComponent<Player>();
        Shield.SetActive(false);
        Timermachine.SetActive(false);
        Burners.SetActive(false);
        engine.SetActive(true);
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Obstacles" && DestroyerMode == false)
        {
            if (deathCountdown < 0f)
            {              
                deathCountdown = 1f;              
                //Debug.Log("Working");
            }
        } else if (collider.tag == "Obstacles" && DestroyerMode == true)
        {
            Destroy(collider.gameObject);           
        }

        if (collider.tag == "Speed Power Up" && speedtimer <= 2.5f)
        {
            speedtimer = 0f;
            speedtimerstart = true;
            num += 1f;          
            player.velocity += num;
            Destroy(collider.gameObject);


        }
        else if (collider.tag == "Slow Power Up" && slowtimer <= 2.5f)
        {
            slowtimer = 0f;           
            slowtimerstart = true;
            Time.timeScale = 0.5f;
            Destroy(collider.gameObject);
        }
        else if (collider.tag == "Destroyer Power Up" && destroytimer <= 2.5f)
        {
            destroytimer = 0f;
            DestroyerMode = true;
            Destroy(collider.gameObject);
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (deathCountdown >= 0f)
        {
            deathCountdown -= 0.25f;//Time.deltaTime;
            if (deathCountdown <= 0f)
            {
                deathCountdown = -1f;
                player.Die();
                speedtimer = 0;
                slowtimer = 0;
                num = 0;
                speedtimerstart = false;
                slowtimerstart = false;
                DestroyerMode = false;
                Burners.SetActive(false);
                Timermachine.SetActive(false);               
                Shield.SetActive(false);
            }
        }

        SpeedUp();
        SlowDown();
        Destroyer();

    }

    private void SpeedUp()
    {
        if (speedtimer >= 10f && speedtimerstart == true)
        {
            speedtimer = 0f;
            speedtimerstart = false;
            player.velocity -= num;
            num = 0;
            Burners.SetActive(false);
            engine.SetActive(true);

        }
        if (speedtimerstart == true)
        {
            speedtimer += Time.deltaTime;
            Burners.SetActive(true);
            engine.SetActive(false);
        }
    }

    private void SlowDown()
    {
        if (slowtimer >= 5f && slowtimerstart == true)
        {
            slowtimer = 0f;
            slowtimerstart = false;
            Time.timeScale = 1f;
            Timermachine.SetActive(false);
        }
        if (slowtimerstart == true)
        {
            slowtimer += Time.deltaTime;
            Timermachine.SetActive(true);
        }
        else if (slowtimerstart == false)
        {
            Time.timeScale = 1f;
        }
    }

    private void Destroyer()
    {
        if (destroytimer >= 10f && DestroyerMode == true)
        {
            destroytimer = 0f;
            DestroyerMode = false;
            Shield.SetActive(false);
        }
        if (DestroyerMode == true)
        {
            destroytimer += Time.deltaTime;
            Shield.SetActive(true);
        }
    }
}
