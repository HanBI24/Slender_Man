using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_collider : MonoBehaviour
{
    public static bool see_slender = false;
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
        if(other.gameObject.name == "Player")
        {
            //Debug.Log("See slender");
            see_slender = true;
        }
    }
}
