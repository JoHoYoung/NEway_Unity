using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarSetting : MonoBehaviour {

    public int[] StarNum;
    public GameObject[] Stars;
    private int Check;
    private int Max;

	// Use this for initialization
	void Start ()
    {
        Scene scene = SceneManager.GetActiveScene();
        Max = SceneManager.sceneCountInBuildSettings - 3;
        Check = scene.buildIndex;
        Check++;
        Stage();
	}
	
    void Stage()
    {
        while (Check <= Max)
        {
            if (PlayerPrefs.GetInt("Score" + (Check).ToString()) >= StarNum[Check - 2] * 0.25 * 100)
            {
                Stars[Check - 2].transform.GetChild(2).gameObject.SetActive(true);
                Stars[Check - 2].transform.GetChild(3).gameObject.SetActive(false);
            }
            if (PlayerPrefs.GetInt("Score" + (Check).ToString()) >= StarNum[Check - 2] * 0.50 * 100)
            {
                Stars[Check - 2].transform.GetChild(0).gameObject.SetActive(true);
                Stars[Check - 2].transform.GetChild(1).gameObject.SetActive(false);
            }
            if (PlayerPrefs.GetInt("Score" + (Check).ToString()) >= StarNum[Check - 2] * 0.75 * 100)
            {
                Stars[Check - 2].transform.GetChild(4).gameObject.SetActive(true);
                Stars[Check - 2].transform.GetChild(5).gameObject.SetActive(false);
            }
            Check++;
        }
    }
}
