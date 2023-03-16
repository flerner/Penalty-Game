using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    private Transform obstaclesSpawner;
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject obstacle;

    private void Awake()
    {
        obstaclesSpawner = GetComponent<Transform>();
        spawnPoints = obstaclesSpawner.GetComponentsInChildren<Transform>().Skip(1).ToArray();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObstacles()
    {
        Instantiate(obstacle, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    }
}
