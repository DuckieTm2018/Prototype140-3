using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (PatrolState))]
[RequireComponent (typeof (ChaseState))]
[RequireComponent (typeof (SearchState))]
[RequireComponent (typeof (KillState))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{

    [SerializeField] LayerMask mask;
    [SerializeField] float detectRange = 10;
    [Tooltip ("The minimum distance the Enemy has to be to its patrol point for it to count as 'At its destination'")]
    [SerializeField] float minDistanceToPatrolPoint = 1;
    [Tooltip ("The time the AI will wait at each point")]
    [SerializeField] float waitTime = 3;
    List<State> states = new List<State> (); // 0 patrol | 1 chase | 2 search | 3 kill
    State currentState;
    Ray ray;
    RaycastHit hit;
    GameObject player;
    NavMeshAgent agent;
    bool waiting;
    bool searching = false;

    void Start ()
    {

        agent = GetComponent<NavMeshAgent> ();

        states.Add (GetComponent<PatrolState> ());
        states.Add (GetComponent<ChaseState> ());
        states.Add (GetComponent<SearchState> ());
        states.Add (GetComponent<KillState> ());

        player = GameObject.Find ("Player");
        if (player == null) Debug.Log ("Enemies cannot find player in the scene. Is the player in the scene and named 'Player'?");

        InitRay ();
        if (CastRayAtPlayer ().collider.CompareTag ("ENEMY")) Debug.Log ("Rays cast will hit the enemy. Is the layer mask on the enemy set to everything except the enemy layer?");

        ChangeState (states [0]);

    }

    void Update ()
    {
        SelectState ();
    }

    void SelectState ()
    {
        var _currentStateName = currentState.GetName ();
        if (CanSeePlayerInRange ())
        {
            if (_currentStateName == "patrol")
                ChangeState (states [1]);
            else if (_currentStateName == "search")
                ChangeState (states [1]);
        }
        else
        {
            if (_currentStateName == "chase")
                ChangeState (states [3]);
            if (_currentStateName == "search")
                if (!searching)
                    ChangeState (states [0]);
        }
    }

    public void ChangeState (State _newState)
    {
        if(currentState != null)
            ExitState ();
        currentState = _newState;
        EnterState ();
    }

    void EnterState ()
    {
        currentState.StateEnter ();
    }

    void PerformStateUpdate ()
    {
        currentState.StateUpdate ();
    }

    void ExitState ()
    {
        currentState.StateExit ();
    }

    bool CanSeePlayerInRange ()
    {
        return CastRayAtPlayer ().collider.CompareTag ("Player");
    }

    RaycastHit CastRayAtPlayer ()
    {
        InitRay ();
        Physics.Raycast (ray, out hit, detectRange, mask);
        return hit;
    }

    void InitRay ()
    {

        ray = new Ray (transform.position, player.transform.position - transform.position);

    }

    public NavMeshAgent Agent ()
    {
        return agent;
    }

    public GameObject Player ()
    {
        return player;
    }

    public bool IsAtDestination ()
    {
        if (Vector3.Distance (transform.position, agent.destination) < minDistanceToPatrolPoint)
            return true;
        else return false;
    }

    public float WaitTime ()
    {
        return waitTime;
    }

    public bool Waiting ()
    {
        return waiting;
    }

    public void SetWaiting(bool newVal)
    {
        waiting = newVal;
    }

    public bool Searching ()
    {
        return searching;
    }

    public void SetSearching(bool newVal)
    {
        searching = newVal;
    }

}
