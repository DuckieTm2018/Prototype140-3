using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour // this will run though out all levels
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GameObject[] waypoints { get; set; }

    public int startinglives = 1; // lives the player will start with 
   

   
    public bool gameIsRunning;

    private GUIStyle guistyle = new GUIStyle();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); //stop sthere being 2 managers
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        gameIsRunning = false;// this will reset if the game stops running
        
    }



    public void Death()
    {

        {
            Debug.Log("death-GameManager"); // a message into console so i know the code is working
            YouDied();
            gameIsRunning = false; // these will not run if teh game is not running hiding teh display
            return;
        }

        
    }

    public void ResetGame()
    {
        instance = null;
        SceneManager.LoadScene("A-Start");// thsi will destoy the game object and take us back to scene 0 wich is the start screen
        Destroy(gameObject);
        gameIsRunning = false; // these will not run if teh game is not running hiding teh display
        return;
    }

   
    public void YouDied() // this wil take us to the you died screen instead of teh next screen
    {

        SceneManager.LoadScene("D-Lose");
        gameIsRunning = false; // these will not run if teh game is not running hiding teh display
        return;


    }

    public void SetWaypoints()
    {
        waypoints = GameObject.FindGameObjectsWithTag("PatrolPoints");
    }
}
