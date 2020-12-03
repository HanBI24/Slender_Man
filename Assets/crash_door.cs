using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash_door : MonoBehaviour
{
    public GameObject carControlScript;
    public GameObject playerControlScript;
    public static bool hit_car = false;
    public GameObject hellKey;

    private AudioSource audioSource;
    public AudioClip appear_sound;

    // Start is called before the first frame update
    void Start()
    {
        hellKey.SetActive(false);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = appear_sound;
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ColliderBottom" || other.gameObject.name =="ColliderFront" || other.gameObject.name =="ColliderBody")
        {
            //Debug.Log("hit car");
            carControlScript.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>().enabled = false;
            playerControlScript.GetComponent<player_control>().enabled = true;
            hit_car = true;
            hellKey.SetActive(true);
            player_control.carCrash = true;
            audioSource.Play();
        }
    }
}
