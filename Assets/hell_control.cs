using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hell_control : MonoBehaviour
{
    float startSceneTime;

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
        transform.Translate(Vector3.up * Time.deltaTime);
        startSceneTime += Time.deltaTime;
        if (startSceneTime > 5.0f)
        {
            audioSource.Play();
        }

        if (startSceneTime > 10.0f)
        {
            SceneManager.LoadScene("ending_scene");
        }
    }

}
