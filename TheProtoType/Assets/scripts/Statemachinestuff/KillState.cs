﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillState : State
{

    private void Start ()
    {
        Init ();
    }

    protected override void Init ()
    {

        base.Init ();

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
