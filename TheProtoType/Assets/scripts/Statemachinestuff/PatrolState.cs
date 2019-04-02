using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{

    [SerializeField] Transform patrolParent;
    Vector3 [] patrolPoints;

    private void Start ()
    {
        name = "patrol";

        List<Vector3> points = new List<Vector3> ();
        foreach(Transform t in patrolParent)
        {
            points.Add (t.position);
        }
        patrolPoints = points.ToArray ();

    }

    public override void StateEnter ()
    {
        base.StateEnter ();
    }

    public override void StateUpdate ()
    {
        base.StateUpdate ();
    }

    public override void StateExit ()
    {
        base.StateExit ();
    }

}
