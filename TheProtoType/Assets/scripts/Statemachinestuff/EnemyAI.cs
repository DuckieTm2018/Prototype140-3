using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PatrolState))]
[RequireComponent (typeof (ChaseState))]
[RequireComponent (typeof (SearchState))]
[RequireComponent (typeof (KillState))]
public class EnemyAI : MonoBehaviour
{

    List<State> states = new List<State> (); // 0 patrol | 1 chase | 2 search | 3 kill
    State currentState;
    Ray ray;
    RaycastHit hit;
    GameObject player;
    [SerializeField] LayerMask mask;
    [SerializeField] float detectRange = 10;

    void Start ()
    {
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

}
