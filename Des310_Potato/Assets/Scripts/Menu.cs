using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script was written by Hamish Hill Github: @HamishHill-WK
//this script controls which panel the user is viewing - hh
//each public function has a corresponding button in the scene 

public class Menu : MonoBehaviour
{
    private GameObject menuPanel;
    private GameObject profilePanel;
    private GameObject optionsPanel;
    private GameObject gamePanel;

    enum States { menu = 0, profile, options, closed };
    States current = States.menu;

    void Start()
    {
        menuPanel = GameObject.Find("MainMenu");
        profilePanel = GameObject.Find("Profile");
        optionsPanel = GameObject.Find("Options");
        gamePanel = GameObject.Find("GameView");

        switchState(States.menu);
    }

    public void enterGame()
    {
        switchState(States.closed);
    }

    public void openProfile()
    {
        switchState(States.profile);
    }

    public void openMenu()
    {
        switchState(States.menu);
    }

    public void openOptions()
    {
        switchState(States.options);
    }

    public void openFarm ()
    {
        SceneManager.LoadScene("Farming");
    }

    public void closeApp()
    {
        Application.Quit();
    }

    private void switchState(States state)
    {
        current = state;
        switch (current)
        {
            case States.menu:
                profilePanel.SetActive(false);
                menuPanel.SetActive(true);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(false);
                break;
            case States.profile:
                profilePanel.SetActive(true);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(false);
                break;
            case States.options:
                profilePanel.SetActive(false);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(true);
                gamePanel.SetActive(false);
                break;            
            case States.closed:
                profilePanel.SetActive(false);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(true);
                break;
        }
    }
    
}
