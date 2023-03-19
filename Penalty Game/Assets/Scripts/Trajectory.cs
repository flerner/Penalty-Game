using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing;

    Transform[] dotsList;
    Vector2 pos;
    float timeStamp;

    // Start is called before the first frame update
    void Start()
    {      
            Hide();
            PrepareDots();      
    }
    void PrepareDots()
    {
        dotsList= new Transform[dotsNumber];
        for(int i = 0; i < dotsNumber; i++) 
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParent.transform;
            dotsList[i].GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        timeStamp = dotSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp);

            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }
    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
