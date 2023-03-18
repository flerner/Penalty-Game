using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private float score;
    private TextMeshProUGUI txtMesh;

    private void Start()
    {
        txtMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //score += Time.deltaTime;
        txtMesh.text = score.ToString("0");
    }

    public void addScore(float goalScore)
    {
        score += goalScore;
    }

}
