using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private int waveCount = 0;
    private BallSpawn ballSpawn;
    private ObstaclesSpawner obstaclesSpawner;
    private EnemySpawner enemySpawner;
    private GameManager gameManager;

    // Start is called before the first frame update
    private void Awake()
    {
        ballSpawn= GameObject.FindGameObjectWithTag("BallSpawns").GetComponent<BallSpawn>();
        obstaclesSpawner= GameObject.FindGameObjectWithTag("ObstaclesSpawns").GetComponent<ObstaclesSpawner>();
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawns").GetComponent<EnemySpawner>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }
    void Start()
    {
        NextRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextRound()
    {
        waveCount++;
        Debug.Log("Round " + waveCount);
        Despawn();
        Spawn();
        gameManager.ResetShots();
        
    }
    private void Despawn()
    {
        ballSpawn.DespawnBalls();
        obstaclesSpawner.DespawnObstacles();
        enemySpawner.DespawnEnemies();
        
    }
    private void Spawn()
    {
        ballSpawn.SpawnBalls();
        obstaclesSpawner.SpawnObstacles(waveCount);
        enemySpawner.SpawnEnemies(waveCount);
    }
    public void RestartWave()
    {
        
        Despawn();
        Spawn();
        gameManager.ResetShots();
    }
}
