using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public GameObject DPM;

    public void DelPrefManager()
    {
        Instantiate(DPM);
    }
}
