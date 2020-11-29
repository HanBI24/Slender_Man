using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class get_memo : MonoBehaviour
{
    public GameObject[] memo;
    public GameObject carKey;
    public GameObject hellKey;

    public Camera mainCamera;
    public Camera endingCamera;

    private AudioSource audio_source;
    public AudioClip hellSound;

    public GameObject hellgi;

    void Start()
    {

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
                    }
                    if (hit.transform.gameObject.name == "memo2")
                    {
                        player_control.getMemo[1] = true;
                        Destroy(memo[1]);
                    }
                    if (hit.transform.gameObject.name == "memo3")
                    {
                        player_control.getMemo[2] = true;
                        Destroy(memo[2]);
                    }
                    if (hit.transform.gameObject.name == "memo4")
                    {
                        player_control.getMemo[3] = true;
                        Destroy(memo[3]);
                    }
                    if (hit.transform.gameObject.name == "memo5")
                    {
                        player_control.getMemo[4] = true;
                        Destroy(memo[4]);
                    }
                    if(hit.transform.gameObject.name == "car_key")
                    {
                        player_control.isCarKey = true;
                        Destroy(carKey);
                    }
                    if(hit.transform.gameObject.name == "hell_key")
                    {
                        player_control.isHellKey = true;


                        SceneManager.LoadScene("ending_scene", LoadSceneMode.Additive);
                        mainCamera.gameObject.SetActive(false);
                        endingCamera.gameObject.SetActive(true);

                        audio_source = gameObject.AddComponent<AudioSource>();
                        audio_source.clip = hellSound;
                        audio_source.loop = true;
                        audio_source.Play();


                        Destroy(hellKey);
                    }
                    if(hit.transform.gameObject.name == "Hell" && player_control.isHellKey)
                    {
                        Debug.Log("Ending");
                        //SceneManager.LoadScene("ending_scene");
                    }
                }
            }
        }
    }

}
