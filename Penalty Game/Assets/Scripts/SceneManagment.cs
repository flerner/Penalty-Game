using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public static SceneManagment Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Penalty")
        {
            MusicPlay.AudioSource.GetComponent<AudioSource>().volume = 0.04f;
        }

        if (SceneManager.GetActiveScene().name == "HighScoreTable")
        {
            MusicPlay.AudioSource.GetComponent<AudioSource>().volume = 0.2f;
        }
    }
}
