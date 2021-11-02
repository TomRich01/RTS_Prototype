using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public WorkerUnit wu_Selected = null;
    public Unit u_Selected = null;

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
            SelectUnit();
            

        }
        else if (Input.GetMouseButton(1))
        {
            TaskUnit();
        }
       
        
    }

    void TaskUnit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Food" || hit.collider.tag == "Wood" || hit.collider.tag == "Stone")
            {
                Vector3 area = hit.collider.gameObject.transform.position;
                wu_Selected.GetTaskPosition(area);
                wu_Selected.tagType = hit.collider.tag;
                wu_Selected.GetResourceObject(hit.collider.GetComponent<ResourceSpawn>());
            }

            if (hit.collider.tag == "Enemy")
            {
                Vector3 area = hit.collider.gameObject.transform.position;
                u_Selected.GetUnitPosition(area);
                
            }


            if (Input.GetMouseButton(0))
            {
                if (hit.transform.gameObject.layer == 7)
                {
                    wu_Selected = null;
                    u_Selected = null;
                }
            }

            
        }
    }

    private void SelectUnit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the unit, so we make sure to check in the parent
            var wunit = hit.collider.GetComponentInParent<WorkerUnit>();
            var unit = hit.collider.GetComponent<Unit>();
            wu_Selected = wunit;

            if (unit.CompareTag("Guard"))
            {
                u_Selected = unit;
            }
            


        }
    }

   
}
