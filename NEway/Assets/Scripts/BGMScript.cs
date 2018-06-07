using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour {

    public static BGMScript BGM;
    // Use this for initialization

    void Start()
    {
        if (BGM == null)
            BGM = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
