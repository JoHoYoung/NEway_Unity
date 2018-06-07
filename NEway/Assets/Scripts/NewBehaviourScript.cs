using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class NewBehaviourScript : MonoBehaviour
{
    public Slider Ditemtime;
    public Slider NowInk;
    private Camera mainCamera = null;           // 메인 카메라         
    public Button HammerBtn;
    public Button PencilBtn;
    public Button MenuBtn;
    public Button DethR;
    public GameObject CollChk;
    public GameObject DrawingIMG;
    public GameObject ErasingIMG;
	public Text InkPercent;
    private float Length;
    private float Ink;
    public float defaultInk = 300.0f;
    
    private bool isClick = false;
    public GameObject point;
    GameObject S;
    private Vector2 PrevPos = new Vector2(0, 0);
    private float Angle;
    private void Start()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Ditem", 0);
        Button Hbtn = HammerBtn.GetComponent<Button>();
        Button Pbtn = PencilBtn.GetComponent<Button>();
        Button Mbtn = MenuBtn.GetComponent<Button>();
        Ditemtime.gameObject.SetActive(false);
        Hbtn.onClick.AddListener(HTaskOnClick);
        Pbtn.onClick.AddListener(PTaskOnClick);
        Ink = 60.0f;
        defaultInk = 60.0f;

    }
    void HTaskOnClick()
    {
        PlayerPrefs.SetInt("Mode", 0);
    }
    void PTaskOnClick()
    {
        PlayerPrefs.SetInt("Mode", 1);
    }
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    void DelLine()
    {
        StartCoroutine("DeleteLine", 1.3f);
    }

    float Dtime = 5.0f;
    private void Update()
    {
		int InkItem = PlayerPrefs.GetInt ("GetInk");
		if (InkItem == 1) {

			Ink += 30;
			if (Ink > defaultInk)
				Ink = defaultInk;

			PlayerPrefs.SetInt ("GetInk", -1);
		}
		InkPercent.text = (int)((Ink / defaultInk) * 100) + "%";
        if(Ink<=defaultInk)
        Ink += 4.5f * Time.deltaTime;
        
        NowInk.value = Ink;

        if (Ink <= 0)
            DrawingIMG.SetActive(false);
        int ditem = PlayerPrefs.GetInt("Ditem");
        if (ditem == 1)
        {
            Ditemtime.gameObject.SetActive(true);
            Dtime -= Time.deltaTime;
            Ditemtime.value = Dtime;
            if (Dtime <= 0.0f)
            {
                PlayerPrefs.SetInt("Ditem", 0);
                Ditemtime.gameObject.SetActive(false);
                Dtime = 5.0f;
            }
        }

        int n = PlayerPrefs.GetInt("Mode");
        if (n == 1&&Ink>=0)
        {
            ErasingIMG.SetActive(false);
            if (Input.GetMouseButton(0))
            {
               Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				DrawingIMG.transform.position = new Vector2 (Pos.x - 0.2f, Pos.y - 0.2f);
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
                    Ink -= Length;
                    if (Ink <= 0)
                        Ink = 0;
                    if (Ink > 0)
                    {
                        S = (GameObject)Instantiate(point, CPos, Quaternion.Euler(0, 0, Angle));
                        S.transform.localScale = new Vector3(Length, 1);
                        Destroy(S, 2.5f);
                    }
                    
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
        else if(n==0)
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
    
}

