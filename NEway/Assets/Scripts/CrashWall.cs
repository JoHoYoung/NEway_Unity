using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashWall : MonoBehaviour
{
    private int count;
    public GameObject Wall;

    private void Start()
    {
        count = 6;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Destroyer"))
        {
            int n = PlayerPrefs.GetInt("Ditem");

            if(n==1)
            {
                count -= 6;
            }
            else count--;

            if (count <= 0)
                Destroy(Wall);
        }
    }
}