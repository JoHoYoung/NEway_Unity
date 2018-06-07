using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour {

	private float Timer = 4.0f;
	public Text text;

    void Awake()
    {
        GameObject.FindWithTag("Player").gameObject.GetComponent<Player>().rb.isKinematic = true;
    }

	void Update()
	{
		Timer -= Time.deltaTime;
		if (Timer >= 1)
			text.text = ((int)Timer).ToString();
		else
        {
            GameObject.FindWithTag("Player").gameObject.GetComponent<Player>().rb.isKinematic = false;
			text.text = "START";
			Destroy(text, 1.0f);
		}
	}
}