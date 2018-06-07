using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManager : MonoBehaviour
{
    // To Use Instantiate Grounds
    public GameObject Obj1;
    public GameObject Obj2;
    private GameObject Obj3;
    public GameObject[] Grounds;
    private int length;

    public GameObject BackGround1;
    public GameObject BackGround2;

    private Vector2 Pos1;
    private Vector2 Pos2;
    private Vector2 Pos3;

    // To Use Compare Position Between Grounds
    public PlayerController Player;

    private Camera camera;

    void Awake()
    {
        camera = Camera.main;
        length = Grounds.Length;
        Pos1 = Obj1.transform.Find("EndPoint").gameObject.transform.position;
        Pos2 = Obj2.transform.Find("EndPoint").gameObject.transform.position;
        InstantiateObj3();
    }

    void Update()
    {
        if(Player.transform.position.x>=Pos1.x+3)
        {
            InstantiateRoutine();
        }

        if(BackGround1.transform.position.x<camera.transform.position.x - 36)
        {
            float distance = BackGround2.transform.position.x - BackGround1.transform.position.x;
            BackGround1.transform.position = new Vector2(BackGround2.transform.position.x + distance, BackGround2.transform.position.y);
            GameObject temp = BackGround1;
            BackGround1 = BackGround2;
            BackGround2 = temp;
        }
    }

    void InstantiateRoutine()
    {
        Destroy(Obj1);
        Obj1 = Obj2;
        Obj2 = Obj3;
        Pos1 = Obj1.transform.Find("EndPoint").gameObject.transform.position;
        Pos2 = Obj2.transform.Find("EndPoint").gameObject.transform.position;
        InstantiateObj3();
    }

    void InstantiateObj3()
    {
        int columnNum = Random.Range(0, length) % length;
        float Position = Random.Range(-3, 3);
        if (columnNum == 3 || columnNum == 4)
            Position = Random.Range(-1.5f, 1.5f);
        Vector2 position = new Vector2(Pos2.x + 10, Position);

        Obj3 = Instantiate(Grounds[columnNum], position, Quaternion.Euler(0, 0, 0));

        int i = 0;
        while(true)
        {
            float enable = Random.Range(0, 10);
            if (enable > 4)
                Obj3.transform.Find("Walls").transform.GetChild(i).gameObject.SetActive(true);

            if (Obj3.transform.Find("Walls").transform.GetChild(i).name == "Final")
                break;
            i++;
        }
    }
}
