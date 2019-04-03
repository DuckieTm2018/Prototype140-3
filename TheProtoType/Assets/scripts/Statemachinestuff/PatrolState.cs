using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (EnemyAI))]
public class PatrolState : State
{

    [Tooltip ("The parent object for all the patrol points")]
    [SerializeField] Transform patrolParent;
    Vector3 [] patrolPoints;
    int currentPoint = 0;

    public override void Init ()
    {
        //Debug.Log ("patrol init");
        base.Init ();

        //brain = GetComponent<EnemyAI> ();

        if (debugState)
        {
            if (patrolParent == null) Debug.Log ("'Patrol Parent' has not been set");
        }

        name = "patrol";

        List<Vector3> points = new List<Vector3> ();
        foreach (Transform t in patrolParent)
        {
            points.Add (t.position);
        }
        patrolPoints = points.ToArray ();

    }

    public override void StateEnter ()
    {
        if (debugState) Debug.Log (string.Format ("{0} started patrolling", gameObject.name));
        //Debug.Log (brain);
        //Debug.Log (brain.gameObject.name);
        brain.Agent ().SetDestination (patrolPoints [currentPoint]);

    }

    public override void StateUpdate ()
    {

        if (debugState) Debug.Log (string.Format ("{0} is patrolliing", gameObject.name));

        if (brain.IsAtDestination ())
        {
            if (!brain.Waiting ())
                StartCoroutine (WaitAtPoint ());
        }
    }

    public override void StateExit ()
    {

        if (debugState) Debug.Log (string.Format ("{0} ended patrolling", gameObject.name));

        StopCoroutine (WaitAtPoint ());
        brain.Agent ().SetDestination (transform.position);
    }

    public Vector3 SelectDestination ()
    {
        currentPoint++;
        if (currentPoint >= patrolPoints.Length)
        {
            currentPoint = 0;
        }

        return patrolPoints [currentPoint];

    }

    IEnumerator WaitAtPoint ()
    {
        brain.SetWaiting(true);
        yield return new WaitForSeconds (brain.WaitTime ());
        brain.Agent ().SetDestination (SelectDestination ());
        brain.SetWaiting(false);
    }

}
