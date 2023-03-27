using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private AudioSource goalSound;

    private GameObject waveManager;
    private WaveManager waves;
    private GameManager gameManager;
    public bool wasGol=false;

   
    
    [SerializeField] private float gol;
    [SerializeField] private Score score;

    private void Awake()
    {
        waveManager = GameObject.FindGameObjectWithTag("WaveManager");
        waves = waveManager.GetComponent<WaveManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball2"))
        {
            //score.addScore(gol);
            //waves.NextRound();
            goalSound.Play();
            wasGol = true;
            gameManager.WinWave();
        }

    }
}
