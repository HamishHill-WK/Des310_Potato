using UnityEngine;

public class Menu : MonoBehaviour
{
    private GameObject menuPanel;
    private GameObject profilePanel;
    private GameObject optionsPanel;
    private GameObject gamePanel;

    enum States { menu = 0, profile, options, closed };
    States current = States.menu;

    // Start is called before the first frame update
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
                // code block
                profilePanel.SetActive(false);
                menuPanel.SetActive(true);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(false);
                break;
            case States.profile:
                // code block
                profilePanel.SetActive(true);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(false);
                break;
            case States.options:
                // code block
                profilePanel.SetActive(false);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(true);
                gamePanel.SetActive(false);
                break;            
            case States.closed:
                // code block
                profilePanel.SetActive(false);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(true);
                break;
        }
    }
    
}
