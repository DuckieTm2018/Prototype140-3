using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtons : MonoBehaviour {


    public GameObject PauseMenu;
	
	
	public void ResumeButton()
    {
        Debug.Log("Resume");
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenu.SetActive(false);

    }

    public void SettingsButton()
    {
        Debug.Log("Settings");
    }

    public void MainMenuButton()
    {
        Debug.Log("Main Menu");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
