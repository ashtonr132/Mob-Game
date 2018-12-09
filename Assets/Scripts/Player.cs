using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public PipeSystem pipeSystem;
    public Pipe currentPipe;
    public float distanceTraveled;
    private float deltaToRotation;
    private float systemRotation;
    private Transform world, rotater;
    private float worldRotation, avatarRotation;
    public float rotationVelocity;
    public MainMenu mainMenu;
    //public float startVelocity;
    //public float[] accelerations;
    public float acceleration, velocity;
    public float period = 0.0f;
    public Text scoreLabel;
    public float ButtonCooler  = 0.5f ; // Half a second before reset
    public int ButtonCount  = 0;


    // Use this for initialization
    public void StartGame()
    {
        distanceTraveled = 0f;
        avatarRotation = 0f;
        systemRotation = 0f;
        worldRotation = 0f;
        velocity = 4f;
        currentPipe = pipeSystem.SetupFirstPipe();
        SetupCurrentPipe();
        pipeSystem.resetMaterial();
        gameObject.SetActive(true);       
        
    }

    private void Awake()
    {
        world = pipeSystem.transform.parent;
        rotater = transform.GetChild(0);
        gameObject.SetActive(false);      
    }

    private void Update() {
        float delta = velocity * Time.deltaTime;
        distanceTraveled += delta;
        systemRotation += delta * deltaToRotation;
        SpeedIncrease();
        pipeSystem.period = period;

        if (systemRotation >= currentPipe.CurveAngle)
        {
            delta = (systemRotation - currentPipe.CurveAngle) / deltaToRotation;
            currentPipe = pipeSystem.SetupNextPipe();
            SetupCurrentPipe();
            systemRotation = delta * deltaToRotation;
        }

        if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        {

            if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
            {
                print("Double Tap");
                //Has double tapped
                rotationVelocity += 360;
            }
            else
            {
                ButtonCooler =  0.25f; //(Random.Range(0, 5) < 2.5f) ? 0.25f : 0.5f;
                ButtonCount += 1;

            }
        }

        if (ButtonCooler > 0)
        {

                ButtonCooler -= 1 * Time.deltaTime;

            Mathf.Clamp(ButtonCooler, 0, 9999f);

        }
        else
        {
                ButtonCount = 0;
                rotationVelocity = 180;
        }
        

        pipeSystem.transform.localRotation =
            Quaternion.Euler(0f, 0f, systemRotation);
        UpdateAvatarRotation();
    }

    public void SpeedIncrease()
    {
        if (period > 30f)
        {
            //Do Stuff
            velocity += 0.5f;
            period = 0;
        }
        period += Time.deltaTime;
    }

    private void UpdateAvatarRotation()
    {
        avatarRotation += rotationVelocity * Time.deltaTime * Input.GetAxis("Horizontal");
        //if (avatarRotation < 0f)
        //{
        //    avatarRotation += 360f;
        //}
        //else if (avatarRotation >= 360f)
        //{
        //    avatarRotation -= 360f;
        //}

        avatarRotation = (avatarRotation < 0f) ? avatarRotation + 360 : avatarRotation % 360; 

        rotater.localRotation = Quaternion.Euler(avatarRotation, 0f, 0f);
        
    }

    private void SetupCurrentPipe()
    {
        deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
        worldRotation += currentPipe.RelativeRotation;
        if (worldRotation < 0f)
        {
            worldRotation += 360f;
        }
        else if (worldRotation >= 360f)
        {
            worldRotation -= 360f;
        }
        world.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);
    }

    public void Die()
    {              
        mainMenu.EndGame(distanceTraveled);
        period = 0;
        gameObject.SetActive(false);        
    }
}