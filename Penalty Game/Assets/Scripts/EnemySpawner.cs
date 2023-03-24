using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject enemyReference;
    private GameObject enemySpawned;
    private List<GameObject> allSpawnedEnemies;

    private void Awake()
    {
        spawnPoints = GetComponent<Transform>().GetComponentsInChildren<Transform>().Skip(1).ToArray();
        allSpawnedEnemies = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies(int wave)
    {
        int cantObstacles = wave / 4;
        GameObject lastObstacle = null;

        //this bucle is for avoiding that two obstacles instantiate at the same position
        for (int i = 0; i < cantObstacles; i++)
        {
            enemySpawned = Instantiate(enemyReference, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            while (lastObstacle != null && enemySpawned.transform.position == lastObstacle.transform.position)
            {
                Destroy(enemySpawned);
                enemySpawned = Instantiate(enemyReference, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            }

            lastObstacle = enemySpawned;
            allSpawnedEnemies.Add(enemySpawned);
        }
    }
    public void DespawnEnemies()
    {
        foreach(GameObject go in allSpawnedEnemies)
        {
            Destroy(go);
        }
    }
}
