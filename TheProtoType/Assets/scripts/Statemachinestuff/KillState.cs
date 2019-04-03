using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (EnemyAI))]
public class KillState : State
{

    public override void Init ()
    {
        //Debug.Log ("kill init");
        base.Init ();

        brain = GetComponent<EnemyAI> ();

        name = "kill";

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
