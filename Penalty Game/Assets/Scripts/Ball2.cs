using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    [SerializeField] AudioSource hitSound2;

    private Rigidbody2D ball;
    float drag = 1f;
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
        
    }

    private void FixedUpdate()
    {
        GraduallyStopTheBall();
    }
    private void GraduallyStopTheBall()
    {
        ball.velocity = Vector2.Lerp(ball.velocity, Vector2.zero, drag * Time.deltaTime);
        if (ball.velocity.sqrMagnitude < 0.01f)
        {
            ball.velocity = Vector2.zero;
        }
    }
    public Vector2 GetBallVelocity()
    {
        return ball.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            hitSound2.Play();
        }
    }
}
