using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InfiniteCameraRun : MonoBehaviour
{
    // Main Camera (Set in Awake)
    private Camera mainCamera = null;

    // Collider Checker
    public GameObject CollChk;
    public GameObject DrawingIMG;
    public GameObject ErasingIMG;

    // Draw Line Source Image
    public GameObject point;

    // Item Time Use Variable
    public Slider ItemTime;   
    private float Dtime = 5.0f;

    // Current Mode (1 : Draw Line / 2 : Erase)
    [HideInInspector]
    public int Mode;

    // Use to Draw Line
    private bool isClick = false;
    private float Length;
    private Vector2 PrevPos = new Vector2(0, 0);
    private float Angle;
    private GameObject S;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        Mode = 3;
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Ditem", 0);
        ItemTime.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Mode == 1 : Pencil Mode
        if (Mode == 1)
        {
            ErasingIMG.SetActive(false);
            if (Input.GetMouseButton(0))
            {
                Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                DrawingIMG.transform.position = new Vector2(Pos.x - 0.2f, Pos.y - 0.2f);
                DrawingIMG.SetActive(true);

                Vector2 CPos;
                GameObject S;
                if (PrevPos == new Vector2(0, 0))
                {
                    PrevPos = new Vector2(Pos.x, Pos.y);
                }
                else
                {
                    CPos.x = (Pos.x + PrevPos.x) / 2.0f;
                    CPos.y = (Pos.y + PrevPos.y) / 2.0f;
                    Angle = Mathf.Atan2((Pos.y - PrevPos.y), (Pos.x - PrevPos.x));
                    Angle *= (180 / 3.14f);
                    Length = Mathf.Sqrt((Pos.y - PrevPos.y) * (Pos.y - PrevPos.y) + (Pos.x - PrevPos.x) * (Pos.x - PrevPos.x));
                    Length /= 0.20f;
                    S = (GameObject)Instantiate(point, CPos, Quaternion.Euler(0, 0, Angle));
                    S.transform.localScale = new Vector3(Length, 1);
                    Destroy(S, 2.5f);

                    PrevPos = new Vector2(Pos.x, Pos.y);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                isClick = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isClick = false;
                DrawingIMG.SetActive(false);
                PrevPos = new Vector2(0, 0);
            }
        }
        // Mode == 2 : Eraser Mode
        else if(Mode == 2)
        {
            DrawingIMG.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                ErasingIMG.SetActive(true);
                if (!isClick)
                {
                    Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    GameObject CollChkClone = Instantiate(CollChk, Pos, CollChk.transform.localRotation);
                    ErasingIMG.transform.position = Pos;

                    Destroy(CollChkClone, 1.0f);
                }
                isClick = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                ErasingIMG.SetActive(false);
                isClick = false;
            }
        }
    }

    // When Called Pencil Button Clicked
    public void PencilButton()
    {
        Mode = 1;
    }

    // When Called Eraser Button Clicked
    public void EraseButton()
    {
        Mode = 2;
    }

    public IEnumerator ItemTimeChk()
    {
        ItemTime.gameObject.SetActive(true);
        while (Dtime > 0)
        {
            Dtime -= Time.deltaTime;
        }
        Dtime = 5.0f;
        PlayerPrefs.SetInt("Ditem", 0);
        ItemTime.gameObject.SetActive(false);

        yield return null;
    }
}