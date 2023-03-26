using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraShot : MonoBehaviour
{

    private GameManager gameManager;
    private const int EXTRA_SHOTS = 2;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Ball2"))
        {
            Destroy(gameObject);
            gameManager.AddShots(EXTRA_SHOTS);

        }
    }

}
