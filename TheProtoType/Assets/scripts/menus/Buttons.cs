using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    public GameObject Setings;
    public GameObject Menu;


    private void Start()
    {
        Setings.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Z-Level");
        Debug.Log("Load Game");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void settingsButton()
    {
        Setings.SetActive(true);
        Menu.SetActive(false);
    }

    public void BackSettings()
    {
        Menu.SetActive(true);
        Setings.SetActive(false);
    }

}
