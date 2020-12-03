using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Hellgi : MonoBehaviour
{
    public static bool isInputHellgi = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isInputHellgi = true;
        }
    }
}
