using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{

    Vector3 lastKnownPos = Vector3.zero;

    [Tooltip ("The time the Enemy will search for the player for")]
    [SerializeField] float searchTime = 3;
    float currentTime;



    private void Start ()
    {
        Init ();
    }

    protected override void Init ()
    {

        base.Init ();

        name = "search"; 

    }

    public override void StateEnter ()
    {

        if (debugState) Debug.Log (string.Format ("{0} started searching", gameObject.name));

        lastKnownPos = brain.Player ().transform.position;

    }

    public override void StateUpdate ()
    {
        if (debugState) Debug.Log (string.Format ("{0} is searching", gameObject.name));
    }

    public override void StateExit ()
    {
        base.StateExit ();
    }

    IEnumerator Search ()
    {
        brain.SetSearching (true);
        while(currentTime < searchTime)
        {

            if (brain.IsAtDestination ())
                if (!brain.Waiting ())
                    StartCoroutine (WaitAtPoint ());

            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame ();
        }
        brain.SetSearching (false);
    }

    IEnumerator WaitAtPoint ()
    {
        brain.SetWaiting (true);
        yield return new WaitForSeconds (brain.WaitTime ());
        try
        {
            brain.Agent ().SetDestination (transform.position + new Vector3(Random.Range(1, 3), 0, Random.Range (1, 3)));
        }
        catch
        {
            Debug.Log (string.Format ("while searching, {0} tried to search for the player off the map", gameObject.name));
        }

        brain.SetWaiting (false);
    }

}
