using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool PauseButtonPressed = false;
    public GameObject pauseMenuUI;
    public Trajectory trajectory;
    // Start is called before the first frame update
    void Start()
    {
        trajectory = GameObject.FindGameObjectWithTag("Trajectory").GetComponent<Trajectory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseButtonPressed)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        PauseButtonPressed = false;
        trajectory.Hide();

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        trajectory.Hide();
    }

    public void PauseButton()
    {
        if (PauseButtonPressed)
        {
            PauseButtonPressed = false;
        }
        else
        {
            PauseButtonPressed = true;
        }

    }
    public void MainMenu()
    {
        SceneManagment.Instance.LoadScene("StartGame");
        Resume();
    }
    public void Quit()
    {
        
    }
}
