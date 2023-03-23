using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject extraShotReference;
    private List<GameObject> spawned;
    private void Awake()
    {
        spawned = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnExtraShot(Vector3 position)
    {
        spawned.Add(Instantiate(extraShotReference, position, Quaternion.identity));
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
