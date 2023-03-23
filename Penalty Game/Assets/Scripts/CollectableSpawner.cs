using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject extraShotReference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnExtraShot(Vector3 position)
    {
        Instantiate(extraShotReference, position, Quaternion.identity);
    }
}
