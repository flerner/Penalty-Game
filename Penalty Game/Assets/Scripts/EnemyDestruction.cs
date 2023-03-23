using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    CollectableSpawner collectableSpawner;
    private void Awake()
    {
        collectableSpawner = GameObject.FindGameObjectWithTag("CollectableSpawner").GetComponent<CollectableSpawner>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball") )
        {
            if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 1.5)
            {
                Destroy(gameObject);
                Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
                collectableSpawner.SpawnExtraShot(transform.position);
            }
            
        }
    }
}
