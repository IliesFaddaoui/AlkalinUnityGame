using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public static bool IsPaused = false;
    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public GameObject infoScreen;
    public GameObject player;
    // Update is called once per frame
    private void Start()
    {
        Time.timeScale = 1f;
        if (infoScreen)
        {
            infoScreen.SetActive(true);
        }

    }
    void Update()
    {
        if (!player)
        {
            Time.timeScale = 0f;
            infoScreen.SetActive(false);
            gameOverScreen.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && player)
        {
            print("bouton escape pressed");
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
    }

    public void Resume()
    {
        gameOverScreen.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Pause()
    {
        if (infoScreen)
        {
            infoScreen.SetActive(false);
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
}
