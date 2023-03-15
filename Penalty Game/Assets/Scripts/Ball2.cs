using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    float drag = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GraduallyStopTheBall();
    }
    private void GraduallyStopTheBall()
    {

        this.transform.GetComponent<Rigidbody2D>().velocity -= this.transform.GetComponent<Rigidbody2D>().velocity * drag * Time.deltaTime;
        if (Math.Abs(this.transform.GetComponent<Rigidbody2D>().velocity.x) < 0.2f || Math.Abs(this.transform.GetComponent<Rigidbody2D>().velocity.y) < 0.2f)
        {
            this.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
