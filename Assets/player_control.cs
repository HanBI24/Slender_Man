using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    private float player_walking_speed = 10.0f;
    private float player_running_speed = 10.0f;
    private float player_rotation_speed = 120.0f;

    private float player_jump_height = 8.0f;
    private float player_max_jump_height = 10.0f;
    private float player_jump_power = 1.0f;

    public static bool in_car = false;

    public Camera mainCamera, noiseCamera;

    public static bool[] getMemo;

    public GameObject carKey;

    public static bool isCarKey = false;
    public static bool isHellKey = false;

    public GameObject[] speak;
    bool[] isSpeaking;
    int cnt = 0;

    public static bool isGetMemo1 = false;
    public static bool isSuccessGetMemo1 = false;
    public static bool isSuccessGetMemo2 = false;
    public static bool isFindCarKey = false;
    public static bool isInCar = false;
    public static bool carCrash = false;
    public static bool isOutCar = false;
    public static bool isFindHellKey = false;
    public static bool isInHell = false;

    // Start is called before the first frame update
    void Start()
    {
        getMemo = new bool[5];
        isSpeaking = new bool[22];
        for(int i=0; i<getMemo.Length; i++)
        {
            getMemo[i] = false;
        }

        for(int i=0; i<20; i++)
        {
            speak[i].gameObject.SetActive(false);
            isSpeaking[i] = false;
        }
        isSpeaking[0] = true;
        carKey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        float distance_per_frame_walk = player_walking_speed * Time.deltaTime;
        float distance_per_frame_run = player_running_speed * Time.deltaTime;
        float degree_per_frame = player_rotation_speed * Time.deltaTime;
        float running_time_check = 0.0f;

        float moving_velocity = Input.GetAxis("Vertical");
        float player_angle = Input.GetAxis("Horizontal");

        this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame_walk);
        this.transform.Rotate(0.0f, player_angle * degree_per_frame, 0.0f);

        /*if (Input.GetKey(KeyCode.LeftControl))
        {
            running_time_check += Time.deltaTime;
            Debug.Log("running " +running_time_check);
            if (running_time_check >= 0.02f)
            {
                this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame_walk);
                Debug.Log("walking_time_over " + running_time_check);
            }
            else 
            {
                this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame_run);
                Debug.Log("running_have_time " + running_time_check);
            }
        }
        else
        {
            if(running_time_check <= 0.0f)
            {
                running_time_check = 0.0f;
                Debug.Log("set time zero " + running_time_check);
            }
            else
            {
                running_time_check -= Time.deltaTime;
                Debug.Log("decrease time " + running_time_check);
            }
        }*/

        if (Input.GetKey(KeyCode.LeftControl))
        {
            this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame_run);
 
        }

        if (Input.GetKeyUp("space"))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up*player_jump_height, ForceMode.Impulse);
        }

        if(cube_collider.see_slender == true)
        {
            showNoiseCamera();
            cube_collider.see_slender = false;
        }
        else
        {
            showMainCamera();
        }

        if (getMemo[0] && getMemo[1] && getMemo[2] && getMemo[3] && getMemo[4])
        {
            carKey.SetActive(true);
            isSuccessGetMemo1 = true;
        }

        
        if (isSpeaking[0])
        {
            cnt++;
            speak[0].SetActive(true);
            isSpeaking[0] = false;
            Invoke("Speak1", 3.0f);
            //getIndex(1);
        }
        else if (isSpeaking[1])
        {
            speak[1].SetActive(true);
            isSpeaking[1] = false;
            Invoke("Speak2", 3.0f);
            //getIndex(2);
        }
        else if (isSpeaking[2])
        {
            speak[2].SetActive(true);
            isSpeaking[2] = false;
            Invoke("Speak3", 3.0f);
            //getIndex(3);
        }
        else if (isSpeaking[3] && isGetMemo1)
        {
            speak[3].SetActive(true);
            isSpeaking[3] = false;
            Invoke("Speak4", 3.0f);
        }
        else if (isSpeaking[4])
        {
            speak[4].SetActive(true);
            isSpeaking[4] = false;
            Invoke("Speak5", 5.0f);
        }
        else if (isSpeaking[5])
        {
            speak[5].SetActive(true);
            isSpeaking[5] = false;
            Invoke("Speak6", 3.0f);
        }
        else if (isSpeaking[6] && isSuccessGetMemo1 && isSuccessGetMemo2)
        {
            speak[6].SetActive(true);
            isSpeaking[6] = false;
            Invoke("Speak7", 5.0f);
        }
        else if (isSpeaking[7])
        {
            speak[7].SetActive(true);
            isSpeaking[7] = false;
            Invoke("Speak8", 4.0f);
        }
        else if (isSpeaking[8])
        {
            speak[8].SetActive(true);
            isSpeaking[8] = false;
            Invoke("Speak9", 5.0f);
        }
        else if (isSpeaking[9])
        {
            speak[9].SetActive(true);
            isSpeaking[9] = false;
            Invoke("Speak10", 5.0f);
        }
        else if (isSpeaking[10] && isFindCarKey)
        {
            speak[10].SetActive(true);
            isSpeaking[10] = false;
            Invoke("Speak11", 5.0f);
        }

        else if (isSpeaking[11] && isInCar)
        {
            speak[11].SetActive(true);
            isSpeaking[11] = false;
            Invoke("Speak12", 3.0f);
        }
        else if (isSpeaking[12] && isOutCar && carCrash)
        {
            speak[12].SetActive(true);
            isSpeaking[12] = false;
            Invoke("Speak13", 3.0f);
        }
        else if (isSpeaking[13])
        {
            speak[13].SetActive(true);
            isSpeaking[13] = false;
            Invoke("Speak14", 3.0f);
        }
        else if (isSpeaking[14])
        {
            speak[14].SetActive(true);
            isSpeaking[14] = false;
            Invoke("Speak15", 5.0f);
        }
        else if (isSpeaking[15])
        {
            speak[15].SetActive(true);
            isSpeaking[15] = false;
            Invoke("Speak16", 3.0f);
        }
        else if (isSpeaking[16])
        {
            speak[16].SetActive(true);
            isSpeaking[16] = false;
            Invoke("Speak17", 3.0f);
        }
        else if (isSpeaking[17] && isFindHellKey)
        {
            speak[17].SetActive(true);
            isSpeaking[17] = false;
            Invoke("Speak18", 3.0f);
        }
        else if (isSpeaking[18] && isInHell)
        {
            speak[18].SetActive(true);
            isSpeaking[18] = false;
            Invoke("Speak19", 10.0f);
        }
        else if (isSpeaking[19])
        {
            speak[19].SetActive(true);
            isSpeaking[19] = false;
            Invoke("Speak20", 10.0f);
        }

    }

    void Speak1()
    {
        isSpeak();
        isSpeaking[1] = true;
    }
    void Speak2()
    {
        isSpeak();
        isSpeaking[2] = true;
    }
    void Speak3()
    {
        isSpeak();
        isSpeaking[3] = true;
    }
    void Speak4()
    {
        isSpeak();
        isSpeaking[4] = true;
    }
    void Speak5()
    {
        isSpeak();
        isSpeaking[5] = true;
    }
    void Speak6()
    {
        isSpeak();
        isSpeaking[6] = true;
    }
    void Speak7()
    {
        isSpeak();
        isSpeaking[7] = true;
    }
    void Speak8()
    {
        isSpeak();
        isSpeaking[8] = true;
    }
    void Speak9()
    {
        isSpeak();
        isSpeaking[9] = true;
    }
    void Speak10()
    {
        isSpeak();
        isSpeaking[10] = true;
    }
    void Speak11()
    {
        isSpeak();
        isSpeaking[11] = true;
    }
    void Speak12()
    {
        isSpeak();
        isSpeaking[12] = true;
    }
    void Speak13()
    {
        isSpeak();
        isSpeaking[13] = true;
    }
    void Speak14()
    {
        isSpeak();
        isSpeaking[14] = true;
    }
    void Speak15()
    {
        isSpeak();
        isSpeaking[15] = true;
    }
    void Speak16()
    {
        isSpeak();
        isSpeaking[16] = true;
    }
    void Speak17()
    {
        isSpeak();
        isSpeaking[17] = true;
    }
    void Speak18()
    {
        isSpeak();
        isSpeaking[18] = true;
    }
    void Speak19()
    {
        isSpeak();
        isSpeaking[19] = true;
    }
    void Speak20()
    {
        isSpeak();
        isSpeaking[20] = true;
    }

    /*void getIndex(int i)
    {
        Invoke("Speak", 3.0f);
        isSpeaking[i] = true;
    }

    void Speak()
    {
        isSpeak();
    }*/

    void isSpeak()
    {
        isSpeaking[0] = false;
        isSpeaking[1] = false;
        speak[0].SetActive(false);
        speak[1].SetActive(false);
        speak[2].SetActive(false);
        speak[3].SetActive(false);
        speak[4].SetActive(false);
        speak[5].SetActive(false);
        speak[6].SetActive(false);
        speak[7].SetActive(false);
        speak[8].SetActive(false);
        speak[9].SetActive(false);
        speak[10].SetActive(false);
        speak[11].SetActive(false);
        speak[12].SetActive(false);
        speak[13].SetActive(false);
        speak[14].SetActive(false);
        speak[15].SetActive(false);
        speak[16].SetActive(false);
        speak[17].SetActive(false);
        speak[18].SetActive(false);
        speak[19].SetActive(false);
    }

    void showNoiseCamera()
    {
        mainCamera.enabled = false;
        noiseCamera.enabled = true;
    }

    void showMainCamera()
    {
        mainCamera.enabled = true;
        noiseCamera.enabled = false;
    }
}
