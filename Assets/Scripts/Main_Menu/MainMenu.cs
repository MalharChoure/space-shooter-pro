using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text playerDisplay;

    public void Start()
    {
        Debug.Log("why is this here");
        playerDisplay.text="Player:"+DBmanager_script.username;
        //playerDisplay.setActive(false);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void load_register_menu()
    {
        SceneManager.LoadScene(3);
    }

    public void load_login_menu()
    {
        SceneManager.LoadScene(2);

    }

    public void loadhighscore()
    {
       SceneManager.LoadScene(4);
    }
}
