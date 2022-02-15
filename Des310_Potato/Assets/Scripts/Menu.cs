using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private GameObject profilePanel;
    // Start is called before the first frame update
    void Start()
    {
        profilePanel = GameObject.Find("Profile");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openProfile()
    {
        profilePanel.setActive(true);
        this.set
    }
}
