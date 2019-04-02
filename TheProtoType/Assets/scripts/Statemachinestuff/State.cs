using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour, IState
{

    protected new string name = "default";

    public virtual void StateEnter ()
    {
        throw new System.NotImplementedException ();
    }

    public virtual void StateExit ()
    {
        throw new System.NotImplementedException ();
    }

    public virtual void StateUpdate ()
    {
        throw new System.NotImplementedException ();
    }

    public string GetName ()
    {
        return name;
    }

}
