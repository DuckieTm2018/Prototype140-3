using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("C-Winner");
            Debug.Log("Win");

            
        }
    }
}
