using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public WorkerUnit u_Selected = null;

    public GameObject marker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectWorker();
            SelectBase();

        }
        else if (u_Selected != null && Input.GetMouseButton(1))
        {

        }
        
    }

    private void SelectWorker()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the unit, so we make sure to check in the parent
            var unit = hit.collider.GetComponentInParent<WorkerUnit>();
            u_Selected = unit;


        }
    }

    private void SelectBase()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Base")
            {
                print("The base!");
            }
            


        }
    }
}
