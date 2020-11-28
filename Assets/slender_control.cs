using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slender_control : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goPlayer();
    }

    void goPlayer()
    {
        agent.SetDestination(player.transform.position);
    }
}
