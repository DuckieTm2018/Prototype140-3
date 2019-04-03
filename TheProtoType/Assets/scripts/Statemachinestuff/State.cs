using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class State : MonoBehaviour, IState
{

    protected new string name = "default";
    [Tooltip ("Will debug messages for this state")]
    [SerializeField] protected bool debugState = false;

    protected EnemyAI brain;

    public virtual void Init ()
    {
        brain = GetComponent<EnemyAI> ();
    }

    public virtual void StateEnter ()
    {
        throw new System.NotImplementedException ();
    }

    public virtual void StateUpdate ()
    {
        throw new System.NotImplementedException ();
    }

    public virtual void StateExit ()
    {
        throw new System.NotImplementedException ();
    }

    public string GetName ()
    {
        return name;
    }

}
