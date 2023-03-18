using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.DeviceSimulation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    Vector2 startPosition, endPosition;
    Vector2 ballVelocity;
    float drag = 0.4f;
    private Rigidbody2D ball;
    private bool isDragging;
    Vector2 direction;
    Vector2 force;
    float distance;
    float pushForce = 2f;
    public Trajectory trajectory;
    [HideInInspector] public Vector3 pos { get { return transform.position; } }


    private void Awake()
    {
        trajectory = GameObject.FindGameObjectWithTag("Trajectory").GetComponent<Trajectory>();
        ball = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
           // startPosition = GetPosition();

        }

        if (isDragging)
        {
            OnDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
            //endPosition = GetPosition();
            //this.transform.GetComponent<Rigidbody2D>().AddForce((startPosition - endPosition) * 50, ForceMode2D.Force);            
        }
       
    }


    void OnDrag()
    {
        endPosition = GetPosition();
        distance = Vector2.Distance(startPosition, endPosition);
        direction = (startPosition - endPosition).normalized;
        force = direction * distance * pushForce;

        Debug.DrawLine(startPosition, endPosition);
        trajectory.UpdateDots(pos, force);
    }
    void OnDragStart()
    {
        startPosition = GetPosition();
        trajectory.Show();
    }
    void OnDragEnd()
    {
        ball.AddForce(force, ForceMode2D.Impulse);
        trajectory.Hide();
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
    public Vector2 GetPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
