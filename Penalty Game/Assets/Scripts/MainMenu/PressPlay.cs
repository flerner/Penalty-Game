using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressPlay : MonoBehaviour
{
    public void LoadScene(string mainMenu)
    {
        SceneManagment.Instance.LoadScene(mainMenu);
    }
}
