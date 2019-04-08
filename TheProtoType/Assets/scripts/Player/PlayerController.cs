using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float crouchSpeed = 2.5f;
    public bool Crouch;
    public GameObject Player;
    public GameObject PauseMenu;
    GameObject [] enemyCams;
    

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        enemyCams = GameObject.FindGameObjectsWithTag ("EnemyCam");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown (KeyCode.Tab))
        {
            SwitchCamera ();
        }


        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);




        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            if (PauseMenu != null) 
                PauseMenu.SetActive(true);
        }



        crouching();
     


    }

    private void SwitchCamera ()
    {
        float closest = Mathf.Infinity;
        GameObject closeCam;
        foreach(var c in enemyCams)
        {
            float cur = Vector3.Distance (transform.position, c.transform.position);
            if (cur < closest)
            {
                closeCam = c;
                closest = cur;
            }
        }

    }

    private void crouching()
    {
        var CrouchKey = Input.GetKey(KeyCode.LeftControl);

        if (!Crouch && CrouchKey)
        {
            Player.transform.localScale += new Vector3(0, -0.5f, 0);
            Crouch = true;
            speed = crouchSpeed;
 

        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = 5f;
          
        }

        Debug.DrawRay(transform.position, Vector3.up * 2f, Color.green);
        if(Crouch && !CrouchKey)
        {
            var cantStand = Physics.Raycast(transform.position, Vector3.up, 2f);

            if (!cantStand)
            {
                Player.transform.localScale += new Vector3 (0, +0.5f, 0);
                Crouch = false;
                speed = 5;
            }
            else if (cantStand)
            {
                Crouch = true;
                speed = crouchSpeed;
            }
        }
    }
}

    

