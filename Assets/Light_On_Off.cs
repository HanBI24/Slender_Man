using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_On_Off : MonoBehaviour
{
    private float light_rotate_speed = 120.0f;
    public GameObject light_obj;
    // Start is called before the first frame update
    Light light;
    Transform tr_light;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        light = GetComponent<Light>();
        tr_light = this.transform;

        if (Input.GetKeyDown("e"))
        {
            if (light.enabled)
            {
                light.enabled = false;
            }
            else
            {
                light.enabled = true;
            }
        }

        if (Input.GetKey("r"))
        {
            this.transform.Rotate(light_rotate_speed * (-1.0f) * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKey("f"))
        {
            this.transform.Rotate(light_rotate_speed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKeyDown("g"))
        {
            light.range += 10.0f;
            light.intensity += 20.0f;
            
            if(light.range > 35.0f && light.intensity > 35.0f)
            {
                light.range = 25.0f;
                light.intensity = 15.0f;
            }
        }
        
    }
}
