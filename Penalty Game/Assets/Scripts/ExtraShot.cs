using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraShot : MonoBehaviour
{
    CollectableSpawner collectableSpawner;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Ball2"))
        {

        }
    }
}
