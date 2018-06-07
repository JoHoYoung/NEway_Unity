using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    private int count;
    public GameObject Wall;
    public GameObject[] Items;

    private void Start()
    {
        count = 6;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Destroyer"))
        {
            int n = PlayerPrefs.GetInt("Ditem");

            if (n == 1)
            {
                count = 0;
            }
            else count--;

            if (count <= 0)
            {
                RandomItem();
                Destroy(Wall);
            }
        }
    }

    void RandomItem()
    {
        GameObject SpeedUp = Instantiate(Items[0], Wall.transform.position, Quaternion.Euler(0, 0, 0));

        int flag = Random.Range(-1, 7);
        if (flag == 0)
            Instantiate(Items[1], Wall.transform.position, Quaternion.Euler(0, 0, 0));
        else if(flag>0)
        {
            for (int i = 0; i < flag; i++)
                Instantiate(Items[2], Wall.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
