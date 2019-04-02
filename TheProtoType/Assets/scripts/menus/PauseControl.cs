//########################################################################################################
/// PauseControl.cs
/////////////////////////////////////////////////////////////////////////////////////////////////////////
/// A simple pause control.  Press P (by default) to pause.  This will activate a UI canvas to be used as the pause menu.
/// Unpause by pressing the pause key again or clicking a button on the pause menu.
/// 
/// While this works as it is, a more elegant setup would be to remove the monobehaviour inheritance
/// and use this script as a property of a game manager.  The pauseMenu and pauseKey properties would be moved to an input or ui manager as well 
/// as the update function that is just checking for a key press.
/// 
/// Tested in Unity 2018.3.x
/// 
/// Notes:  
///         * Setting Time.timeScale to float.Epsilon rather than 0 allows for the UI to still work while paused.
///         
///         * Coroutines ignore timeScale.  Any coroutine that needs to be paused with the game needs to check and wait 
///           (use the static property PauseControl.Paused to determine the state).
///         
///         * Animator components intended to continue animating whilst the game is paused need to have their "update mode" property
///           set to 'unscaled time'.  This also applies to the "Update Method" property of any Timeline director components.
///         
/// By Paul Hedley.  22/02/2019
//########################################################################################################

using UnityEngine;

public class PauseControl : MonoBehaviour
{

    public static bool Paused { get; private set; }

    public GameObject pauseMenu; //note: DO NOT attach this script to the pauseMenu object!
    public KeyCode pauseKey = KeyCode.P;

    private void Start()
    {

        /*
        // unblock this chunk of code when you are debugging...
        // ##### DEBUG ########################################################
        if (!pauseMenu)
        {
            Debug.LogError("PauseControl on "+gameObject.name+" needs the pauseMenu property assigned!");
            this.enabled = false;
            return;
        }
        */

        pauseMenu.SetActive(false);
    }

    // Update is just running here for the purposes of the example.
    // In a proper production, this would be handled by a manager.
    private void Update()
    {
        if (Input.GetKeyUp(pauseKey))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        Paused = !Paused;

        /*
        if (Paused)
        {
            Time.timeScale = float.Epsilon;  // use float.Epsilon instead of 0 else the resume button won't get any events!
            pauseMenu.SetActive(true); 
        }
        else
        {
            Time.timeScale = 1f; ;
            pauseMenu.SetActive(false);
        }
        */
        // The two lines below do the same thing as the commented out 'if/else' statement above....
        Time.timeScale = Paused ? float.Epsilon : 1f;
        pauseMenu.SetActive(Paused);
    }
}
