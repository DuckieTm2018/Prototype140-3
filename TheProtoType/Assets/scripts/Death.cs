using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    bool dead = false;

    void OnTriggerEnter(Collider col) // when the player hits a collider with this script it will taek effect
    {
        if (col.gameObject.CompareTag("Player")) // this only works with items that have the player tag
        {
            if (dead) return;

            Debug.Log("Player hit the death zone!"); // a message in console so i can tell the code is working
            SceneManager.LoadScene("Z-Level");
        }
    }
}
