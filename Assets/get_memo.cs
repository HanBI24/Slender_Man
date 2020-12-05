using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class get_memo : MonoBehaviour
{
    public GameObject[] memo;
    public GameObject carKey;
    public GameObject hellKey;

    public Camera mainCamera;
    public Camera endingCamera;
    public Camera hellCamera;

    private AudioSource audio_source;
    public AudioClip hellSound;

    public GameObject hellgi;

    bool[] isGet;

    public GameObject[] getMemo;
    public GameObject getCarKey;
    public GameObject getHellKey;

    bool isMemo5 = false;
    bool isCarKey = false;
    bool isHellKye = false;

    public GameObject leftLight, rightLight;

    public GameObject slenderControl;
    public GameObject hellControl;
    public GameObject hellControlCamera;
    public GameObject hellLeftLightControl, hellRightLightControl;

    public static bool[] isGetMemoSpeed;


    void Start()
    {
        isGet = new bool[7];
        isGetMemoSpeed = new bool[4];
        hellCamera.enabled = false;
        for(int i=0; i<getMemo.Length; i++)
        {
            getMemo[i].gameObject.SetActive(false);
        }

        for(int i=0; i<7; i++)
        {
            isGet[i] = false;
        }

        for(int i=0; i<isGetMemoSpeed.Length; i++)
        {
            isGetMemoSpeed[i] = false;
        }
        getCarKey.gameObject.SetActive(false);
        getHellKey.gameObject.SetActive(false);
        leftLight.gameObject.SetActive(false);
        rightLight.gameObject.SetActive(false);
        slenderControl.GetComponent<slender_control>().enabled = false;
        hellControl.GetComponent<hell_control>().enabled = false;
        hellControlCamera.GetComponent<hell_control>().enabled = false;
        hellLeftLightControl.SetActive(false);
        hellRightLightControl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    /*if(memo.name == "memo1")
                    {
                        Destroy(memo);
                    }*/
                    Debug.Log(hit.transform.gameObject.name);
                    if(hit.transform.gameObject.name == "memo1")
                    {
                        player_control.getMemo[0] = true;
                        Destroy(memo[0]);
                        isGet[0] = true;
                        slenderControl.GetComponent<slender_control>().enabled = true;
                    }
                    if (hit.transform.gameObject.name == "memo2")
                    {
                        player_control.getMemo[1] = true;
                        Destroy(memo[1]);
                        isGet[1] = true;
                        isGetMemoSpeed[0] = true;
                    }
                    if (hit.transform.gameObject.name == "memo3")
                    {
                        player_control.getMemo[2] = true;
                        Destroy(memo[2]);
                        isGet[2] = true;
                        isGetMemoSpeed[1] = true;
                    }
                    if (hit.transform.gameObject.name == "memo4")
                    {
                        player_control.getMemo[3] = true;
                        Destroy(memo[3]);
                        isGet[3] = true;
                        isGetMemoSpeed[2] = true;
                    }
                    if (hit.transform.gameObject.name == "memo5")
                    {
                        player_control.getMemo[4] = true;
                        Destroy(memo[4]);
                        isGet[4] = true;
                        isGetMemoSpeed[3] = true;
                    }
                    if(hit.transform.gameObject.name == "car_key")
                    {
                        player_control.isCarKey = true;
                        Destroy(carKey);
                        isGet[5] = true;
                    }
                    if(hit.transform.gameObject.name == "hell_key")
                    {
                        isGet[6] = true;
                        player_control.isHellKey = true;
                        player_control.isFindHellKey = true;
                        Destroy(hellKey);
                    }
                    if(hit.transform.gameObject.name == "Hell" && player_control.isHellKey && Input_Hellgi.isInputHellgi)
                    {
                        Debug.Log("Ending");

                        hellControl.GetComponent<hell_control>().enabled = true;
                        hellControlCamera.GetComponent<hell_control>().enabled = true;
                        hellLeftLightControl.SetActive(true);
                        hellRightLightControl.SetActive(true);

                        leftLight.gameObject.SetActive(true);
                        rightLight.gameObject.SetActive(true);

                        player_control.isInHell = true;
                        hellCamera.enabled = true;

                        player_control.isInHell = true;

                        mainCamera.gameObject.SetActive(false);
                        endingCamera.gameObject.SetActive(true);

                        audio_source = gameObject.AddComponent<AudioSource>();
                        audio_source.clip = hellSound;
                        audio_source.loop = true;
                        audio_source.Play();
                    }
                }
            }
        }

        if(player_control.getMemo[0] == true && isGet[0])
        {
            getMemo[0].gameObject.SetActive(true);
            isGet[0] = false;
            Invoke("isGetMemo", 3.0f);
        }
        else if (player_control.getMemo[1] == true && isGet[1])
        { 
            getMemo[1].gameObject.SetActive(true);
            isGet[1] = false;
            Invoke("isGetMemo", 3.0f);
        }
        else if (player_control.getMemo[2] == true && isGet[2])
        {
            getMemo[2].gameObject.SetActive(true);
            isGet[2] = false;
            Invoke("isGetMemo", 3.0f);
        }
        else if (player_control.getMemo[3] == true && isGet[3])
        {
            getMemo[3].gameObject.SetActive(true);
            isGet[3] = false;
            Invoke("isGetMemo", 3.0f);
        }
        else if (player_control.getMemo[4] == true && isGet[4])
        {
            getMemo[4].gameObject.SetActive(true);
            isGet[4] = false;
            isMemo5 = true;
            Invoke("isGetMemo", 3.0f);
        }
        else if (player_control.isCarKey == true && isGet[5])
        {
            getCarKey.gameObject.SetActive(true);
            isGet[5] = false;
            isCarKey = true;
            Invoke("isGetMemo", 3.0f);
        }
        else if (player_control.isHellKey == true && isGet[6])
        {
            getHellKey.gameObject.SetActive(true);
            isGet[6] = false;
            isHellKye = true;
            Invoke("isGetMemo", 3.0f);
        }
    }

    void isGetMemo()
    {
        player_control.isGetMemo1 = true;
        getMemo[0].gameObject.SetActive(false);
        getMemo[1].gameObject.SetActive(false);
        getMemo[2].gameObject.SetActive(false);
        getMemo[3].gameObject.SetActive(false);
        getMemo[4].gameObject.SetActive(false);
        getCarKey.gameObject.SetActive(false);
        getHellKey.gameObject.SetActive(false);

        if (isMemo5)
        {
            Invoke("isGetMemoSuccess2", 1.0f);
        }
        if (isCarKey)
        {
            Invoke("isFindCarKey", 1.0f);
        }
        if (isHellKye)
        {
            Invoke("isFindHellKey", 1.0f);
        }
    }

    void isGetMemoSuccess2()
    {
        player_control.isSuccessGetMemo2 = true;
    }

    void isFindCarKey()
    {
        player_control.isFindCarKey = true;
    }

    void isFindHellKey()
    {
        player_control.isFindHellKey = true;
    }

}
