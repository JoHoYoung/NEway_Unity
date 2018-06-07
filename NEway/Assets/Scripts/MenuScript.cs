using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public NewBehaviourScript Script;
    public static bool GameIsPaused = false;
    public GameObject ButtonUISet;
    public GameObject Panel;
    public Button CBtn;
    public Button RBtn;
    public Button BBtn;
    public Text CurScore;
    public Text BestScore;
    private int Star;
    private int Best;
    private int temp = 0;
    private int curscene;
    private Vector2 Scale;
    private bool A;

    public void Resume()
    {
        ButtonUISet.gameObject.SetActive(true);
        Panel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerPrefs.SetInt("Mode", OriginInt);
    }


    private void Start()
    {
        A = false;
        Scene scene = SceneManager.GetActiveScene();
        curscene = scene.buildIndex;
        Star = PlayerPrefs.GetInt("Score");
        Best = PlayerPrefs.GetInt("Score" + curscene.ToString());
        Scale = BestScore.transform.localScale;
        CurScore.text = "Score : " + temp.ToString();
        BestScore.text = "Best : " + Best.ToString();

        Button ToChapbtn = CBtn.GetComponent<Button>();
        Button Restartbtn = RBtn.GetComponent<Button>();
        Button Backbtn = BBtn.GetComponent<Button>();

        ToChapbtn.onClick.AddListener(CTaskOnClick);
        Restartbtn.onClick.AddListener(RTaskOnClick);
        Backbtn.onClick.AddListener(BTaskOnClick);
    }
    void CTaskOnClick()
    {
        SceneManager.LoadScene("Chapter");
    }
    void RTaskOnClick()
    {
        Scene NS = SceneManager.GetActiveScene();
        int Now = NS.buildIndex;
        SceneManager.LoadScene(Now);

    }
    void BTaskOnClick()
    {
        Resume();
    }
    private int OriginInt;

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
        CurScore.text = "Score : " + temp.ToString();

        if (temp < Star)
        {
            temp += 50;
        }
        else
        {
            temp = Star;
            if (Best < Star)
            {
                Best = Star;
                PlayerPrefs.SetInt("Score" + curscene.ToString(), Star);
                BestScore.transform.localScale = Scale * 1.2f;
                BestScore.text = "Best : " + PlayerPrefs.GetInt("Score" + curscene.ToString()).ToString();
                A = true;
            }
        }

        if (A)
        {
            Vector2 TempScale = BestScore.transform.localScale;
            TempScale.x -= 0.01f;
            TempScale.y -= 0.01f;
            BestScore.transform.localScale = TempScale;
            if ((Vector2)BestScore.transform.localScale == (Vector2)Scale)
                A = false;
        }

    }

    public void Pause()
    {
        OriginInt = PlayerPrefs.GetInt("Mode");
        PlayerPrefs.SetInt("Mode", 2);
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
        Debug.Log("Quitting Game…");
    }
}