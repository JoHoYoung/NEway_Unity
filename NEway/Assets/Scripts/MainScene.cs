using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {

    public Button StartButton;
    public Button InfinityButton1;
    public Button InfinityButton2;
    public Button QuitButton;

    public void Starting()
    {
        SceneManager.LoadScene("Chapter");
    }

    public void Infinity1()
    {
        SceneManager.LoadScene("Chapter_Infy");
    }

    public void Inifinity2()
    {
        SceneManager.LoadScene("Chapter_Infy2");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
