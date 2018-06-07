using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Player
    public Rigidbody2D rb;

    // About to Player's velocity
    private float velocity;
    [HideInInspector]
    public float velocity_Scale;

    // Variable to Save Current Score & Represent it
    private int score;
    private float flag;
    public Text Scoretext;
    private float Itemtime;

    // Camera
    public InfiniteCameraRun Cam;

    // Audio Variable
    private AudioSource hsAudio;
    public AudioClip Pickupsound;

    // Use this for initialization
    void Start()
    {
        Scoretext.gameObject.SetActive(true);
        Scoretext.text = "Score : " + score.ToString();
        score = 0;
        flag = 0;
        velocity_Scale = 2;

        this.hsAudio = this.gameObject.AddComponent<AudioSource>();
        this.hsAudio.clip = this.Pickupsound;
        this.hsAudio.loop = false;
    }

    void Update()
    {
        flag += (Time.deltaTime * 10);
        if (flag >= 1)
        {
            flag--;
            score++;
        }
        Scoretext.text = "Score : " + score.ToString();

        velocity_Scale = score / 1000;
        if (velocity_Scale < 2)
            velocity_Scale = 2;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            velocity = rb.velocity.y;
            rb.velocity = new Vector2(Mathf.Sqrt(4 - velocity * velocity), velocity);
            Vector2 temp = rb.velocity.normalized;
            temp.x *= 1.2f;
            if (PlayerPrefs.GetInt("SpeedItem") == 1)
                temp.x += velocity_Scale * 0.5f;
            rb.velocity = velocity_Scale * temp;
        }
    }
    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            velocity = rb.velocity.y;
            rb.velocity = new Vector2(Mathf.Sqrt(4 - velocity * velocity), velocity);
            Vector2 temp = rb.velocity.normalized;
            if (PlayerPrefs.GetInt("SpeedItem") == 1)
                temp.x += velocity_Scale * 0.5f;
            rb.velocity = velocity_Scale * rb.velocity.normalized;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ditem")
        {
            StartDitem();
            collider.gameObject.SetActive(false);
        }

        if(collider.gameObject.tag == "SpeedItem")
        {
            StartSitem();
        }

        if (collider.gameObject.tag == "Star")
        {
            this.hsAudio.Play();
            score += 100;
            collider.gameObject.SetActive(false);
        }

        if (collider.gameObject.tag == "DethLine")
        {
            PlayerPrefs.SetInt("Score", score);
            Time.timeScale = 0.0f;
            GameObject.Find("Canvas").transform.Find("DethPannel").gameObject.SetActive(true);
        }
    }

    void StartDitem()
    {
        PlayerPrefs.SetInt("Ditem", 1);
        Cam.StartCoroutine(Cam.ItemTimeChk());
    }

    void StartSitem()
    {
        Itemtime = 3.0f;
        PlayerPrefs.SetInt("SpeedItem", 1);
        StartCoroutine(SpeedUp());
    }

    IEnumerator SpeedUp()
    {
        while (Itemtime > 0)
        {
            Itemtime -= Time.deltaTime;
        }
        PlayerPrefs.SetInt("SpeedItem", 0);

        yield return null;
    }
}
