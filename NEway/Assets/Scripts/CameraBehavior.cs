using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraBehavior : MonoBehaviour
{

    public GameObject pl;
	public Button CBtn;
	public Button RBtn;
	public Button NBtn;
	private void Start()
	{
		Button ToChapbtn = CBtn.GetComponent<Button>();
		Button Restartbtn = RBtn.GetComponent<Button>();
		Button Nextbtn = NBtn.GetComponent<Button>();
		ToChapbtn.onClick.AddListener(CTaskOnClick);
		Restartbtn.onClick.AddListener(RTaskOnClick);
		Nextbtn.onClick.AddListener(NTaskOnClick);
	}

	void CTaskOnClick()
	{
		Application.LoadLevel("Chapter");
	}
	void RTaskOnClick()
	{	
		Scene NS = SceneManager.GetActiveScene ();
		int Now = NS.buildIndex;
		SceneManager.LoadScene(Now);
		
	}
	void NTaskOnClick()
	{
		int Next = PlayerPrefs.GetInt ("Next");
		Debug.Log (Next);
		switch (Next)
		{
		case 2:
			Application.LoadLevel ("Chapter2");
			break;
		case 3:
			Application.LoadLevel ("Chapter3");
			break;
		case 4:
			Application.LoadLevel ("Chapter4");
			break;
		case 5:
			Application.LoadLevel ("Chapter5");
			break;
		case 6:
			Application.LoadLevel ("Chapter6");
			break;
		case 7:
			Application.LoadLevel ("Chapter7");
			break;
		
		}

	}

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 targerpos = new Vector3(pl.transform.position.x + 7, gameObject.transform.position.y, -50);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targerpos, Time.deltaTime * 2f);

    }
   
}
