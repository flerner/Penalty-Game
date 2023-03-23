using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicPlay : MonoBehaviour
{
    public GameObject objectMusic;
    
    public static AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        objectMusic = GameObject.FindWithTag("Music");
        AudioSource = objectMusic.GetComponent<AudioSource>();

    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 1;

    }
}
