using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int health = 3;
    private int shots = 5;
    private WaveManager waveManager;
    private Goal goal;
    private Ball ball = null;
    private int score = 0;
    private GuiManager guiManager;

    // Start is called before the first frame update

    private void Awake()
    {
        waveManager = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>();
        goal = GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal>();
        guiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GuiManager>();


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ball == null) 
        {
            ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        }
        if(shots == 0 && ball.GetBallVelocity().magnitude == 0)
        {
            LooseWave();
        }
        if(health == 0)
        {
            SceneManagment.Instance.LoadScene("MainMenu");
        }
    }
    public void UpdateShots()
    {
        shots--;
        guiManager.UpdateShots(shots);
        Debug.Log("Shots remaining: " + shots);
    }
    public void ResetShots()
    {
        shots = 5;
    }
    public void LooseWave()
    {
        waveManager.RestartWave();
        health--;
        guiManager.UpdateLives(health);
        Debug.Log("Lives remaining" + health);
    }
    public void WinWave()
    {
        score++;
        waveManager.NextRound();
        goal.wasGol = false;
        guiManager.UpdateScore(score);
    }
}
