using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject extraShotReference;
    [SerializeField]
    private GameObject extraLife;
    private List<GameObject> spawned;
    private void Awake()
    {
        spawned = new List<GameObject>();
    }

    private void Update()
    {
        Debug.Log(Random.Range(0, 10));
    }
    public void SpawnExtraShot(Vector3 position)
    {
        spawned.Add(Instantiate(extraShotReference, position, Quaternion.identity));
    }
    public void SpawnExtraLife(Vector3 position)
    {
        spawned.Add(Instantiate(extraLife, position, Quaternion.identity));
    }

    public void SpawnRandom(Vector3 position)
    {
        int i = Random.Range(0, 10);
        if(i >=0 && i < 8)
        {
            SpawnExtraShot(position);
        }
        else
        {
            SpawnExtraLife(position);
        }
    }
    public void DespawnAll()
    {
        int cant = spawned.Count;
        for(int i= 0; i < cant; i++)
        {
            Destroy(spawned[0]);
            spawned.RemoveAt(0);
        }
    }


}
