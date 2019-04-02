using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{

    private void Start ()
    {
        Init ();
    }

    protected override void Init ()
    {

        base.Init ();

        name = "chase";

    }

    public override void StateEnter ()
    {
        if (debugState) Debug.Log (string.Format ("{0} started chasing", gameObject.name));

        brain.Agent ().SetDestination (brain.Player ().transform.position);

    }

    public override void StateUpdate ()
    {

        if (debugState) Debug.Log (string.Format ("{0} is chasing", gameObject.name));


        brain.Agent ().SetDestination (brain.Player ().transform.position);

    }

    public override void StateExit ()
    {

        if (debugState) Debug.Log (string.Format ("{0} ended chasing", gameObject.name));

        brain.Agent ().SetDestination (transform.position);

    }

}
