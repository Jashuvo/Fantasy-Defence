using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private NavMeshAgent enemyNavigation;
    [SerializeField]
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        enemyNavigation = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        enemyNavigation.SetDestination(player.position);
    }
}
