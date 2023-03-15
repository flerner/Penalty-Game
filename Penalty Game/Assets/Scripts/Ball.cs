using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    Vector2 startPosition, endPosition;
    Vector2 ballVelocity;
    float drag = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = GetPosition();
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPosition = GetPosition();
            this.transform.GetComponent<Rigidbody2D>().AddForce((startPosition - endPosition) * 50, ForceMode2D.Force);            
        }
       
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
    public Vector2 GetPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
