using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage_2 : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float Timer = 4.0f;
    public Text text;

    void Start()
    {
        rb2d.isKinematic = true;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer >= 1)
            text.text = ((int)Timer).ToString();
        else
        {
            text.text = "START";
            rb2d.isKinematic = false;
            gameObject.GetComponent<PlayerController>().enabled = true;
            GameObject.FindWithTag("MainCamera").gameObject.GetComponent<InfiniteCameraRun>().Mode = 1;
            GameObject.FindWithTag("MainCamera").gameObject.GetComponent<CameraMov>().enabled = true;
            gameObject.GetComponent<StartMessage_2>().enabled = false;
            Destroy(text, 1.0f);
        }
    }
}