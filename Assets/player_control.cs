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

    public Camera mainCamera, noiseCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance_per_frame_walk = player_walking_speed * Time.deltaTime;
        float distance_per_frame_run = player_running_speed * Time.deltaTime;
        float degree_per_frame = player_rotation_speed * Time.deltaTime;

        float moving_velocity = Input.GetAxis("Vertical");
        float player_angle = Input.GetAxis("Horizontal");

        this.transform.Translate(Vector3.forward * moving_velocity * distance_per_frame_walk);
        this.transform.Rotate(0.0f, player_angle * degree_per_frame, 0.0f);

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
