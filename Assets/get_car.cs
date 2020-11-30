using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_car : MonoBehaviour
{
    public GameObject carControlScript;
    public GameObject playerControlScript;
    public Camera player_camera;
    public Camera car_camera;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_control.in_car && Input.GetKeyDown("i") && player_control.isCarKey)
        {
            player_control.isInCar = true;
            player_control.isOutCar = false;
            if (crash_door.hit_car)
            {
                player_control.isCarKey = false;
                Debug.Log("No car");
            }
            else
            {
                carControlScript.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>().enabled = true;
                playerControlScript.GetComponent<player_control>().enabled = false;
                player_control.in_car = false;
                player_camera.gameObject.SetActive(false);
                car_camera.gameObject.SetActive(true);
            }
            
        }
        if (player_control.in_car == false && Input.GetKeyDown("o"))
        {
            Debug.Log("Out car");
            player_control.isOutCar = true;
            carControlScript.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>().enabled = false;
            playerControlScript.GetComponent<player_control>().enabled = true;
            player_camera.gameObject.SetActive(true);
            car_camera.gameObject.SetActive(false);

            GameObject player_spawn_point = GameObject.Find("player_spawn");
            //Instantiate(player, player_spawn_point.transform.position, player_spawn_point.transform.rotation);
            player.transform.position = new Vector3(player_spawn_point.transform.position.x, player_spawn_point.transform.position.y, player_spawn_point.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("enter car");
            player_control.in_car = true;
        }
    }
}
