using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DethScript : MonoBehaviour {

	// Use this for initialization
	public Button MainButton;
	public Button RestartButton;
    public Text CurScore;
    public Text BestScore;
    private int Star;
    private int Best;
    private int temp = 0;
    private int curscene;
    private Vector2 Scale;
    private bool A;

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
    }

    void Update()
    {
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
    
    public void LoadMain()
	{
        SceneManager.LoadScene("Chapter");
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Main");
    }

	public void Restart()
	{	
		Scene NS = SceneManager.GetActiveScene ();
		int Now = NS.buildIndex;
		SceneManager.LoadScene(Now);
	}
}
