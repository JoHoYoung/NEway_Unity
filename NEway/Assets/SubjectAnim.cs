using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectAnim : MonoBehaviour {

    public Animator SubAnim;

    void Awake()
    {
        Time.timeScale = 1;
        SubAnim.SetBool("Writing", true);
        SubAnim.SetBool("Positioning", true);
        if (PlayerPrefs.GetInt("MAIN") == 1)
        {
            SubAnim.SetBool("Writing", false);
            PlayerPrefs.SetInt("MAIN", 0);
        }
    }

    public void setting()
    {
        SubAnim.SetBool("Writing", false);
    }

    public void Positioning()
    {
        GameObject.Find("Canvas").transform.Find("Button Set").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Object").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Bird").gameObject.SetActive(true);
        SubAnim.SetBool("Positioning", false);
    }
}
