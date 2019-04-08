﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    [SerializeField] int numberOfKeys = 2;
    int keysCollected;
    Animator anim;

    private void Start ()
    {
        anim = GetComponent<Animator> ();
    }

    public void OpenDoor ()
    {
        if(keysCollected == numberOfKeys)
        {
            anim.SetTrigger ("Open");
        }
    }

    public void CollectKey ()
    {
        keysCollected++;
    }

}
