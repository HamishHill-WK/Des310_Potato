using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBookObject_script : MonoBehaviour
{
    public Canvas recipeBook;
    public GameObject recipePanel;

    // Start is called before the first frame update
    void Start()
    {
        //Get obejct References
        GameObject tempObject = GameObject.Find("Recipebook Canvas");

        if (tempObject != null)
        {
            recipeBook = tempObject.GetComponent<Canvas>();
            if (recipeBook == null)
            {
                Debug.Log("Could not locate canvas object on " + tempObject.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Hello world this click was detected");
        // this object was clicked - do something

        if (recipeBook.enabled == false)
        {
            recipeBook.enabled = true;

            if (recipePanel.activeInHierarchy == true)
                recipePanel.SetActive(false);
        }
    }
}
