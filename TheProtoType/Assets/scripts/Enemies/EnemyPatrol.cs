using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//helped by paul and jake

public class EnemyPatrol : MonoBehaviour {

    public GameObject[] waypoints; // empty game objects with positions on tagged a s waypoints

    private NavMeshAgent agent;

    private int destPoint = 0;


    // Use this for initialization
    void Start () {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();

        waypoints = GameManager.Instance.waypoints;

       

        destPoint = Random.Range(0, waypoints.Length - 1);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (waypoints.Length == 0)
            return;


        //set the agent to go to the currently selected destination
        //agent.destination = waypoints[destPoint].transform.position;
        agent.SetDestination(waypoints[destPoint].transform.position);

        //check to see if agent is near current waypoint
        if(Vector3.Distance(transform.position ,waypoints[destPoint].transform.position)<0.5f)
        {
            Debug.Log(gameObject.name + " has reached destination " + waypoints[destPoint].name);
            //choose the next position randomly in the array as the destination, cycling to the start if necessary
            destPoint = (destPoint + 1) % waypoints.Length;
        }

    }
}
