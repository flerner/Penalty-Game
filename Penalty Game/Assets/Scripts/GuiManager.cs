using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text lives;
    public TMP_Text shots;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAll(int _score, int _lives, int _shots)
    {
        UpdateScore(_score);
        UpdateLives(_lives);
        UpdateShots(_shots);
    }

    public void UpdateScore(int _score)
    {
        score.text = "Score: " + _score;
    }
    public void UpdateLives(int _lives)
    {
        lives.text = "Lives: " + _lives;
    }
    public void UpdateShots(int _shots)
    {
        shots.text = "Shots: " + _shots;
    }
}
