using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private NavMeshAgent enemyNavigation;
    [SerializeField]
    private Transform player;
    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        enemyNavigation = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameManager.instance.Player.transform.position;
        if (Vector3.Distance(playerPos,gameObject.transform.position) > 2)
        {
            enemyNavigation.enabled = true;
            enemyNavigation.SetDestination(player.position);
        }
        else
        {
            enemyNavigation.enabled = false;
        }
    }
}
