using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour
{
    public void LoadScene(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
    }
}
