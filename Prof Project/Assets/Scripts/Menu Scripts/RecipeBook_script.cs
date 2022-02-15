using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RecipeBook_script : MonoBehaviour
{
    public Canvas recipeBook;

    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");

            recipeBook.enabled = false;
        }
    }
    
    void OnMouseDown()
    {
        Debug.Log("Hello world this click was detected");
        // this object was clicked - do something

        if (recipeBook.enabled == false)
        {
             recipeBook.enabled = true;
        }
    }
}
