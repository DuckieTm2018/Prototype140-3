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
    public GameObject playerCamera;
    GameObject [] enemyCams;
    [Tooltip("The length of time that the player will stay in the enemies camera")]
    [SerializeField] float switchTime = 3;
    [SerializeField] float cooldownTime = 6;
    bool canSwitch = true;
    

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        enemyCams = GameObject.FindGameObjectsWithTag ("EnemyCam");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown (KeyCode.Tab))
        {
            if(canSwitch)
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
        canSwitch = false;
        float closest = Mathf.Infinity;
        GameObject closeCam = playerCamera;
        Debug.Log(enemyCams.Length);
        foreach(var c in enemyCams)
        {
            float cur = Vector3.Distance (transform.position, c.transform.position);
            Debug.Log(cur);
            if (cur < closest)
            {
                closeCam = c;
                closest = cur;
            }
        }

        playerCamera.SetActive (false);
        closeCam.SetActive (true);
        StartCoroutine(CameraStuff(closeCam));

    }

    IEnumerator CameraStuff (GameObject cam)
    {
        yield return new WaitForSeconds (switchTime);
        cam.SetActive (false);
        playerCamera.SetActive (true);
        yield return new WaitForSeconds (cooldownTime);
        canSwitch = true;
    }

    private void crouching()
    {
        var CrouchKey = Input.GetKey(KeyCode.LeftShift);

        if (!Crouch && CrouchKey)
        {
            Player.transform.localScale += new Vector3(0, -0.5f, 0);
            Crouch = true;
            speed = crouchSpeed;
 

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
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

    

