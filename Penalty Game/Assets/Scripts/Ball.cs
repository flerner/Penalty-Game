using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    Vector2 startPosition, endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(startPosition);
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.GetComponent<Rigidbody2D>().AddForce((startPosition - endPosition) * 50 , ForceMode2D.Force);
            Debug.Log(endPosition);
        }
    }
}
