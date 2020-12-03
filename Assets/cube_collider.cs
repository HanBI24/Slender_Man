using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_collider : MonoBehaviour
{
    public static bool see_slender = false;
    public GameObject main_camera;
    private AudioSource audioSource;
    public AudioClip appear_sound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = appear_sound;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            //Debug.Log("See slender");
            see_slender = true;
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
