using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int waveCount = 0;
    private BallSpawn ballSpawn;
    private ObstaclesSpawner obstaclesSpawner;
    private EnemySpawner enemySpawner;

    // Start is called before the first frame update
    private void Awake()
    {
        ballSpawn= GameObject.FindGameObjectWithTag("BallSpawns").GetComponent<BallSpawn>();
        obstaclesSpawner= GameObject.FindGameObjectWithTag("ObstaclesSpawns").GetComponent<ObstaclesSpawner>();
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawns").GetComponent<EnemySpawner>();
    }
    void Start()
    {
        
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
    }
    private void Despawn()
    {
        ballSpawn.DespawnBalls();
        
    }
    private void Spawn()
    {
        ballSpawn.SpawnBalls();
    }
}
