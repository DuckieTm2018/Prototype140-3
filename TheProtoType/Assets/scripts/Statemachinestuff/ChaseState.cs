using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (EnemyAI))]
public class ChaseState : State
{

    public override void Init ()
    {
        //Debug.Log ("chase init");
        base.Init ();

        brain = GetComponent<EnemyAI> ();

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
