using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_sound : MonoBehaviour
{
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
        audioSource.Play();
    }
}
