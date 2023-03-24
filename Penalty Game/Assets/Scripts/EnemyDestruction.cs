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
            Debug.Log(collision.relativeVelocity.magnitude);
            if (collision.relativeVelocity.magnitude > 5)
            {
                //collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude
                Destroy(gameObject);
                
                collectableSpawner.SpawnRandom(transform.position);
            }
            
        }
    }
}
