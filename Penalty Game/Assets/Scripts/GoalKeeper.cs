using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    CollectableSpawner collectableSpawner;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        collectableSpawner = GameObject.FindGameObjectWithTag("CollectableSpawner").GetComponent<CollectableSpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
       // target = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection= direction;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Ball").transform;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }
}
