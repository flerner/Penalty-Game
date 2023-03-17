using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    private Transform obstaclesSpawner;
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject obstacleReference;
    private GameObject obstacleSpawned;
    private List<GameObject> allSpawnedObstacles;

    private void Awake()
    {
        obstaclesSpawner = GetComponent<Transform>();
        spawnPoints = obstaclesSpawner.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        allSpawnedObstacles = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnObstacles(int wave)
    {
        int cantObstacles = wave / 3;
        GameObject lastObstacle = null;

        //this bucle is for avoiding that two obstacles instantiate at the same position
        //FIXME obstacles keep spawining when all its spawn points are taken.
        for(int i = 0; i < cantObstacles; i++) 
        {                  
            obstacleSpawned = Instantiate(obstacleReference, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            while(lastObstacle!= null && obstacleSpawned.transform.position == lastObstacle.transform.position) 
            {
                Destroy(obstacleSpawned);
                obstacleSpawned = Instantiate(obstacleReference, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            }

            lastObstacle = obstacleSpawned;
            allSpawnedObstacles.Add(obstacleSpawned);
        }
        
    }
    public void DespawnObstacles()
    {
        foreach(GameObject go in allSpawnedObstacles) 
        {
            Destroy(go);
        }
    }
}
