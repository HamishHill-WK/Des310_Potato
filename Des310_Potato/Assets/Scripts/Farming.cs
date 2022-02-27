using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script was written by Hamish Hill Github: @HamishHill-WK

public class Farming : MonoBehaviour
{
    private GameObject potato;
    private GameObject spade;
    private GameObject soil;

    private bool plantable;
    private bool planted;

    enum selectable { none = 0, potato, spade };
    selectable currentSelect = selectable.none;

    private MeshRenderer potatoMesh;
    private MeshRenderer spadeMesh;
    private MeshRenderer soilMesh;

    public Material mat1;
    public Material mat2;

    public int harvest;

    private Camera camera1;
    private Ray ray;
    private RaycastHit hit;

    private void startLoad()
    {
        potato = GameObject.Find("Potato");
        spade = GameObject.Find("Spade");
        soil = GameObject.Find("Soil");
        camera1 = Camera.main;

        potatoMesh = potato.GetComponent<MeshRenderer>();
        spadeMesh = spade.GetComponent<MeshRenderer>();
        soilMesh = soil.GetComponent<MeshRenderer>();

        plantable = soil.GetComponent<soil>().plantable;
        planted = soil.GetComponent<soil>().planted;
    }

    private void userInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = camera1.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == potato)
                {
                    Selector(selectable.potato);
                    //Debug.Log("potato");
                   // pSelect = true;
                }
                
                if (hit.collider.gameObject == spade)
                {
                    Selector(selectable.spade);
                   // Debug.Log("spade");
                  //  pSelect = true;
                }   

                if (hit.collider.gameObject == soil && currentSelect == selectable.spade )
                {
                    if (!plantable && !planted)
                    {
                        Selector(selectable.none);

                       // plantable = true;
                        soil.GetComponent<soil>().plantable = true;
                        //Debug.Log("spade");
                        //  pSelect = true;
                    }

                    if(planted)
                    {
                        Selector(selectable.none);

                        Harvest(soil.GetComponent<soil>().yield);

                        //soil.GetComponent<soil>().plantable = true;
                        soil.GetComponent<soil>().planted = false;
                        //harvest += soil.GetComponent<soil>().yield;

                        soil.GetComponent<soil>().yield = 0.0f;
                    }
                }            
                
                if (hit.collider.gameObject == soil && currentSelect == selectable.potato )
                {
                    if (plantable)
                    {
                        Selector(selectable.none);

                        soil.GetComponent<soil>().plantable = false;
                        soil.GetComponent<soil>().planted = true;
                        //plantable = false;
                        //planted = true;
                    }
                }
            }
        }
    }

    private void Selector(selectable object1)
    {
        currentSelect = object1;
        switch (currentSelect)
        {
            case selectable.none:
                // code block
                potatoMesh.material = mat2;
                spadeMesh.material = mat2;
                break;

            case selectable.potato:
                // code block
                potatoMesh.material = mat1;
                spadeMesh.material = mat2;
                break;

            case selectable.spade:
                // code block
                potatoMesh.material = mat2;
                spadeMesh.material = mat1;
                break;
        }
    }

    private void Harvest(float yield)
    {
        harvest = (int)Mathf.CeilToInt(yield/10.0f);
    }

    private void updateVars()
    {
        plantable = soil.GetComponent<soil>().plantable;
        planted = soil.GetComponent<soil>().planted;
    }

    // Start is called before the first frame update
    void Start()
    {
        startLoad();
    }

    // Update is called once per frame
    void Update()
    {
        userInput();

        updateVars();
    }
}
 