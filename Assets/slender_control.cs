using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class slender_control : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;

    private NavMeshAgent slenderSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goPlayer();
        slenderSpeed = GetComponent<NavMeshAgent>();
        if (get_memo.isGetMemoSpeed[0])
        {
            slenderSpeed.speed += 0.5f;
        }
        if (get_memo.isGetMemoSpeed[1])
        {
            slenderSpeed.speed += 0.5f;
        }
        if (get_memo.isGetMemoSpeed[2])
        {
            slenderSpeed.speed += 0.5f;
        }
        if (get_memo.isGetMemoSpeed[3])
        {
            slenderSpeed.speed += 0.5f;
        }

    }

    void goPlayer()
    {
        agent.SetDestination(player.transform.position);
    }
}
