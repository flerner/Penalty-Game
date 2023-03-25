using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highScoreEntryTransformList;
    //public static HighscoreTable Instance;

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}


        UpdateTable();
    }

    public void UpdateTable()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.transform.Find("HighScoreEntryTemplate");

        

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        
        
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        if (highScores == null)
        {
            return;
        }
        //sorting code
        for (int i = 0; i < highScores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highScores.highscoreEntryList.Count; j++)
            {
                if (highScores.highscoreEntryList[j].score > highScores.highscoreEntryList[i].score)
                {
                    HighScoreEntry temp = highScores.highscoreEntryList[i];
                    highScores.highscoreEntryList[i] = highScores.highscoreEntryList[j];
                    highScores.highscoreEntryList[j] = temp;
                }
            }
        }



        highScoreEntryTransformList = new List<Transform>();

        //Create 10 first positions from the loaded and sorted list
        if (highScores.highscoreEntryList.Count > 0)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    CreateHighscoreEntryTransform(highScores.highscoreEntryList[i], entryContainer, highScoreEntryTransformList);
            //}
            int i = 0;
            while (i < highScores.highscoreEntryList.Count && i < 10)
            {
                CreateHighscoreEntryTransform(highScores.highscoreEntryList[i], entryContainer, highScoreEntryTransformList);
                i++;
            }
        }
    }
    private void CreateHighscoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 80f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;

        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = rank + "ST"; break;
            case 2: rankString = rank + "ND"; break;
            case 3: rankString = rank + "RD"; break;
        }


        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;
        int score = highScoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
        string name = highScoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }
    //this class represent a single highscore entry
    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }

    private class HighScores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }

    public static void AddHighScoreEntry(int score, string name)
    {
        //Create highscore
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name};

        //Load highscores
        string jsonString = PlayerPrefs.GetString("highScoreTable");

        //if no highscore are stored so jsonString is null
        
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        if (highScores == null)
        {
            HighScores highscores2 = new HighScores();
            highscores2.highscoreEntryList= new List<HighScoreEntry>();
            highscores2.highscoreEntryList.Add(new HighScoreEntry { score = score, name = name });
            string json1 = JsonUtility.ToJson(highscores2);
            PlayerPrefs.SetString("highScoreTable", json1);
            PlayerPrefs.Save();
            return;
        }
        //create a copy and sort to check if is able to save it
        string jsonString1 = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores1 = JsonUtility.FromJson<HighScores>(jsonString);
        List<HighScoreEntry> clonedHighScoreEntryList = new List<HighScoreEntry>(highScores1.highscoreEntryList);
        for (int i = 0; i < clonedHighScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < clonedHighScoreEntryList.Count; j++)
            {
                if (clonedHighScoreEntryList[j].score > clonedHighScoreEntryList[i].score)
                {
                    HighScoreEntry temp = clonedHighScoreEntryList[i];
                    clonedHighScoreEntryList[i] = clonedHighScoreEntryList[j];
                    clonedHighScoreEntryList[j] = temp;
                }
            }
        }

        //Add to the list
        
        if (clonedHighScoreEntryList.Count >= 10 && score > clonedHighScoreEntryList[9].score)
        {
            highScores.highscoreEntryList.Add(highScoreEntry);
        }else if(clonedHighScoreEntryList.Count >= 0 && clonedHighScoreEntryList.Count < 10)
        {
            highScores.highscoreEntryList.Add(highScoreEntry);
        }
       
        

        //Save the List
        string json = JsonUtility.ToJson(highScores);
        Debug.Log(json);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }
    private void ClearJsonFile()
    {
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        int cantPos = highScores.highscoreEntryList.Count;
        for (int i=0; i < cantPos; i++)
        {
            highScores.highscoreEntryList.RemoveAt(0);
        }
        
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }
}
