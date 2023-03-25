using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int health = 3;
    private int shots = 5;
    private WaveManager waveManager;
    private Goal goal;
    private Ball ball = null;
    private int score = 0;
    private GuiManager guiManager;
    public static string nameInput;
    private Ball2 ball2 = null;
    private CollectableSpawner collectableSpawner;
    //private HighscoreTable highscoreTable;

    // Start is called before the first frame update


    private float _duration = 5f;
    private float _timer = 0f;

    private void Awake()
    {
        waveManager = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>();
        goal = GameObject.FindGameObjectWithTag("Goal").GetComponent<Goal>();
        guiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GuiManager>();
        collectableSpawner = GameObject.FindGameObjectWithTag("CollectableSpawner").GetComponent<CollectableSpawner>();
        // highscoreTable = GameObject.FindGameObjectWithTag("HighScoreTable").GetComponent<HighscoreTable>();


    }
    void Start()
    {
        guiManager.UpdateLives(health);
        guiManager.UpdateShots(shots);
        guiManager.UpdateScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        if(ball == null) 
        {
            ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        }
        if(ball2 == null)
        {
            ball2 = GameObject.FindGameObjectWithTag("Ball2").GetComponent<Ball2>();
        }
        if(shots == 0 && ball.GetBallVelocity().magnitude == 0 && ball2.GetBallVelocity().magnitude == 0)
        {
            LooseWave();
        }
        if(shots == 0)
        {
            _timer += Time.deltaTime;
            Debug.Log(_timer);
            if (_timer >= _duration)
            {
                _timer = 0f;
                LooseWave();
            }

        }
        if(health == 0)
        {
            CreateNewPositionInHighscoreTable();
            SceneManagment.Instance.LoadScene("HighScoreTable");
        }
    }
    public void UpdateShots()
    {
        shots--;
        guiManager.UpdateShots(shots);
        
    }
    public void ResetShots()
    {
        shots = 5;
    }
    public void LooseWave()
    {
        waveManager.RestartWave();
        health--;
        guiManager.UpdateAll(score, health, shots);
        collectableSpawner.DespawnAll();
    }
    public void WinWave()
    {
        score++;
        waveManager.NextRound();
        goal.wasGol = false;
        guiManager.UpdateAll(score, health, shots);
        collectableSpawner.DespawnAll();
    }

    private void CreateNewPositionInHighscoreTable()
    {
        HighscoreTable.AddHighScoreEntry(score, nameInput);
        
    }
    public static void AddInputName(string name)
    {
        nameInput = name;
    }
    public bool CanShoot()
    {
        return shots > 0;
    }
    public void AddShots(int shots)
    {
        this.shots += shots;
        guiManager.UpdateShots(this.shots);
    }
    public void AddLife(int life)
    {
        if (health < 5)
        {
            this.health += life;
            guiManager.UpdateLives(health);
        }
    }
}
