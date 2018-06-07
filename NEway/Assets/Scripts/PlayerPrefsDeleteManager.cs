using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDeleteManager : MonoBehaviour {
    
    void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
