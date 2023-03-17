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
    private Rigidbody2D ball;

    private void Awake()
    {
        ball = GetComponent<Rigidbody2D>();
    }
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
    //private void GraduallyStopTheBall()
    //{

    //    this.transform.GetComponent<Rigidbody2D>().velocity -= this.transform.GetComponent<Rigidbody2D>().velocity * drag * Time.deltaTime;
    //    if (Math.Abs(this.transform.GetComponent<Rigidbody2D>().velocity.x) < 0.1f || Math.Abs(this.transform.GetComponent<Rigidbody2D>().velocity.y) < 0.1f)
    //    {
    //        this.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    //    }
    //}
    private void GraduallyStopTheBall()
    {
        ball.velocity = Vector2.Lerp(ball.velocity, Vector2.zero, drag * Time.deltaTime);
        if (ball.velocity.sqrMagnitude < 0.01f)
        {
            ball.velocity = Vector2.zero;
        }
    }
    public Vector2 GetPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
