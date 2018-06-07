using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject ButtonUISet;
    public GameObject Panel;
    public GameObject StartText;
    private int OriginInt;

    public void Resume()
    {
        StartText.SetActive(true);
        ButtonUISet.gameObject.SetActive(true);
        Panel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        gameObject.GetComponent<InfiniteCameraRun>().Mode = OriginInt;
    }
    
    public void Restart()
    {
        Scene NS = SceneManager.GetActiveScene();
        int Now = NS.buildIndex;
        SceneManager.LoadScene(Now);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        StartText.SetActive(false);
        OriginInt = GameObject.FindWithTag("MainCamera").gameObject.GetComponent<InfiniteCameraRun>().Mode;
        GameObject.FindWithTag("MainCamera").gameObject.GetComponent<InfiniteCameraRun>().Mode = 3;
        ButtonUISet.gameObject.SetActive(false);
        Panel.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quitgame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
}