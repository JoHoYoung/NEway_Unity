using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChBtnController : MonoBehaviour {

	public Button Ch1Can;
	public Button Ch1Cleared;
	public Button Ch2Non;
	public Button Ch2Can;
	public Button Ch2Cleared;
	public Button Ch3Non;
	public Button Ch3Can;
	public Button Ch3Cleared;
	public Button Ch4Non;
	public Button Ch4Can;
	public Button Ch4Cleared;
	public Button Ch5Non;
	public Button Ch5Can;
	public Button Ch5Cleared;
	public Button Tomain;

	// Use this for initialization
	void Start () {

		Button Ch1Can2=Ch1Can.gameObject.GetComponent<Button>();
		Button Ch1Cleared2=Ch1Cleared.gameObject.GetComponent<Button>();
		Button Ch2Non2=Ch2Non.gameObject.GetComponent<Button>();
		Button Ch2Can2=Ch2Can.gameObject.GetComponent<Button>();
		Button Ch2Cleared2=Ch2Cleared.gameObject.GetComponent<Button>();
		Button Ch3Non2=Ch3Non.gameObject.GetComponent<Button>();
		Button Ch3Can2=Ch3Can.gameObject.GetComponent<Button>();
		Button Ch3Cleared2=Ch3Cleared.gameObject.GetComponent<Button>();
		Button Ch4Non2=Ch4Non.gameObject.GetComponent<Button>();
		Button Ch4Can2=Ch4Can.gameObject.GetComponent<Button>();
		Button Ch4Cleared2=Ch4Cleared.gameObject.GetComponent<Button>();
		Button Ch5Non2=Ch5Non.gameObject.GetComponent<Button>();
		Button Ch5Can2=Ch5Can.gameObject.GetComponent<Button>();
		Button Ch5Cleared2=Ch5Cleared.gameObject.GetComponent<Button>();
		Button Tomain2 = Tomain.gameObject.GetComponent<Button> ();

		Ch1Can2.onClick.AddListener (GoCh1);
		Ch1Cleared2.onClick.AddListener (GoCh1);
		Ch2Can2.onClick.AddListener (GoCh2);
		Ch2Cleared2.onClick.AddListener (GoCh2);
		Ch3Can2.onClick.AddListener (GoCh3);
		Ch3Cleared2.onClick.AddListener (GoCh3);
		Ch4Can2.onClick.AddListener (GoCh4);
		Ch4Cleared2.onClick.AddListener (GoCh4);
		Ch5Can2.onClick.AddListener (GoCh5);
		Ch5Cleared2.onClick.AddListener (GoCh5);
		Tomain2.onClick.AddListener (TomainF);

		Ch1Can.gameObject.SetActive(true);
		Ch1Cleared.gameObject.SetActive(false);
		Ch2Non.gameObject.SetActive(true);
		Ch2Can.gameObject.SetActive(false);
		Ch2Cleared.gameObject.SetActive(false);
		Ch3Non.gameObject.SetActive(true);
		Ch3Can.gameObject.SetActive(false);
		Ch3Cleared.gameObject.SetActive(false);
		Ch4Non.gameObject.SetActive(true);
		Ch4Can.gameObject.SetActive(false);
		Ch4Cleared.gameObject.SetActive(false);
		Ch5Non.gameObject.SetActive(true);
		Ch5Can.gameObject.SetActive(false);
		Ch5Cleared.gameObject.SetActive(false);

		
	}

	void GoCh1()
	{
		SceneManager.LoadScene("Chapter1");
	}
	void GoCh2()
	{
        SceneManager.LoadScene("Chapter2");
	}
	void GoCh3()
	{
        SceneManager.LoadScene("Chapter3");
	}
	void GoCh4()
	{
        SceneManager.LoadScene("Chapter4");
	}
	void GoCh5()
	{
        SceneManager.LoadScene("Chapter5");
	}
	void TomainF()
	{
        PlayerPrefs.SetInt("MAIN", 1);
        SceneManager.LoadScene("Main");
	}
	
	// Update is called once per frame
	void Update () {
		int ch1, ch2, ch3, ch4, ch5;
		ch1 = PlayerPrefs.GetInt ("Ch1Clear");
		ch2 = PlayerPrefs.GetInt ("Ch2Clear");
		ch3 = PlayerPrefs.GetInt ("Ch3Clear");
		ch4 = PlayerPrefs.GetInt ("Ch4Clear");
		ch5 = PlayerPrefs.GetInt ("Ch5Clear");

		if (ch1 == 1) {
			Ch1Can.gameObject.SetActive (false);
			Ch1Cleared.gameObject.SetActive (true);
			Ch2Non.gameObject.SetActive (false);
			Ch2Can.gameObject.SetActive (true);
		}

		if (ch2 == 1) {
			Ch2Can.gameObject.SetActive (false);
			Ch2Cleared.gameObject.SetActive (true);
			Ch3Non.gameObject.SetActive (false);
			Ch3Can.gameObject.SetActive (true);
		}
		if (ch3 == 1) {
			Ch3Can.gameObject.SetActive (false);
			Ch3Cleared.gameObject.SetActive (true);
			Ch4Non.gameObject.SetActive (false);
			Ch4Can.gameObject.SetActive (true);
		}
		if (ch4 == 1) {
			Ch4Can.gameObject.SetActive (false);
			Ch4Cleared.gameObject.SetActive (true);
			Ch5Non.gameObject.SetActive (false);
			Ch5Can.gameObject.SetActive (true);
		}
		if (ch5 == 1) {
			Ch5Can.gameObject.SetActive (false);
			Ch5Cleared.gameObject.SetActive (true);
		}
	}
}
