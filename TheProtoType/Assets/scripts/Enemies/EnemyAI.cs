using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour

{


    public float damage = 10f;
    public float range = 100f;
    //public float impactForce

    public Camera GaurdCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public float health = 100f;
    //The target player
    public Transform player;
    
    public float walkingDistance = 10.0f; // the distance that the 
    //In what time will the enemy complete the journey between its position and the players position
    public float smoothTime = 10.0f;
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = Vector3.zero;


    //Call every frame
    void Update()
    {
        //Look at the player
        transform.LookAt(player);
        //Calculate distance between player
        float distance = Vector3.Distance(transform.position, player.position);
        //If the distance is smaller than the walkingDistance
        if (distance < walkingDistance)
        {
            //Move the enemy towards the player with smoothdamp
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
        }
    }


  


}