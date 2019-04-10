using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    DoorManager dm;

    private void Start ()
    {
        dm = GameObject.Find ("LockedDoor").GetComponent<DoorManager> ();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy ()
    {
        dm.CollectKey ();
    }

}
