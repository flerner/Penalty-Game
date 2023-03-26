using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;

    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball2" || collision.gameObject.tag == "Ball")
        {
            clickSound.Play();
        }
    }
}
