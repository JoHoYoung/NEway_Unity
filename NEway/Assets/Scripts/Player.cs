using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    bool Ditem;
    public Rigidbody2D rb;
    private int CurScene;
    private Scene scene;
    public Animator playerAnimator;
    public Text Scoretext;

    private AudioSource hsAudio;
    public AudioClip Pickupsound;
	// Use this for initialization
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt("Star", 0);
        CurScene = scene.buildIndex;
        Scoretext.text = "Score : " + PlayerPrefs.GetInt("Star").ToString();

        this.hsAudio = this.gameObject.AddComponent<AudioSource>();
        this.hsAudio.clip = this.Pickupsound;
        this.hsAudio.loop = false;
    }
    float temp;

    
   void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            temp = rb.velocity.y;
            rb.velocity = new Vector2(Mathf.Sqrt(4 - temp * temp), temp);
            rb.velocity = 2 * rb.velocity.normalized;
        }
    }
    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            temp = rb.velocity.y;
            rb.velocity = new Vector2(Mathf.Sqrt(4 - temp * temp), temp);
            rb.velocity = 2 * rb.velocity.normalized;
        }
    }
    public void PanelOn()
    {
        GameObject.Find("Canvas").transform.Find("Clear").gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ClearAnim()
    {
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
        rb.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y + 0.2f);
        gameObject.transform.Find("Model2").gameObject.SetActive(true);
        gameObject.transform.Find("Head").gameObject.SetActive(false);
        gameObject.transform.Find("Body").gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
		if (collider.gameObject.tag == "Ditem") {
			StartDitem ();
			collider.gameObject.SetActive (false);
		}
		if (collider.gameObject.tag == "Inkitem") {
			PlayerPrefs.SetInt ("GetInk", 1);
			collider.gameObject.SetActive (false);
		}
        if (collider.gameObject.tag == "Star")
        {
            this.hsAudio.Play();
            int temp = PlayerPrefs.GetInt("Star");
            temp+=100;
            PlayerPrefs.SetInt("Star", temp);
            Debug.Log(PlayerPrefs.GetInt("Star"));
            Scoretext.text = "Score : " + PlayerPrefs.GetInt("Star").ToString();
            collider.gameObject.SetActive(false);
        }
        if (collider.gameObject.tag == "DethLine")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Star"));
            Time.timeScale = 0.0f;
            GameObject.Find("Canvas").transform.Find("DethPannel").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ButtonUISet").gameObject.SetActive(false);
        	
		}
        else if (collider.gameObject.tag == "Chapter1Clear")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Star"));
            playerAnimator.SetBool("Clear", true);
            GameObject.Find("Canvas").transform.Find("ButtonUISet").gameObject.SetActive(false);
            PlayerPrefs.SetInt("Ch1Clear", 1);
            PlayerPrefs.SetInt("Restart", 2);
            PlayerPrefs.SetInt("Next", 2);
        }
        else if (collider.gameObject.tag == "Chapter2Clear")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Star"));
            playerAnimator.SetBool("Clear", true);
            GameObject.Find("Canvas").transform.Find("ButtonUISet").gameObject.SetActive(false);
            PlayerPrefs.SetInt("Ch2Clear", 1);
            PlayerPrefs.SetInt("Restart", 3);
            PlayerPrefs.SetInt("Next", 3);
        }
        else if (collider.gameObject.tag == "Chapter3Clear")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Star"));
            playerAnimator.SetBool("Clear", true);
            GameObject.Find("Canvas").transform.Find("ButtonUISet").gameObject.SetActive(false);
            PlayerPrefs.SetInt("Ch3Clear", 1);
            PlayerPrefs.SetInt("Restart", 4);
            PlayerPrefs.SetInt("Next", 4);
        }
        else if (collider.gameObject.tag == "Chapter4Clear")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Star"));
            playerAnimator.SetBool("Clear", true);
            GameObject.Find("Canvas").transform.Find("ButtonUISet").gameObject.SetActive(false);
            PlayerPrefs.SetInt("Ch4Clear", 1);
            PlayerPrefs.SetInt("Restart", 5);
            PlayerPrefs.SetInt("Next", 5);
        }
        else if (collider.gameObject.tag == "Chapter5Clear")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Star"));
            playerAnimator.SetBool("Clear", true);
            GameObject.Find("Canvas").transform.Find("ButtonUISet").gameObject.SetActive(false);
            PlayerPrefs.SetInt("Ch5Clear", 1);
            PlayerPrefs.SetInt("Restart", 6);
            PlayerPrefs.SetInt("Next", 6);
        }
    }

    void StartDitem()
    {
        PlayerPrefs.SetInt("Ditem", 1);        
    }

}
