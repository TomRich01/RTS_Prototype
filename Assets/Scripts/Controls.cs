using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public WorkerUnit wu_Selected = null;
    [SerializeField] GameObject selectedMarker;
    
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

        HandleSelectedMarker();
    }

    private void SelectUnit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the unit, so we make sure to check in the parent
            var wunit = hit.collider.GetComponentInParent<WorkerUnit>();
            wu_Selected = wunit;
           


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

        }
    }

    void HandleSelectedMarker()
    {
        if (wu_Selected == null && selectedMarker.activeInHierarchy)
        {
            selectedMarker.SetActive(false);
            selectedMarker.transform.SetParent(null);
        }
        else if (wu_Selected != null && selectedMarker.transform.parent != wu_Selected.transform)
        {
            selectedMarker.SetActive(true);
            selectedMarker.transform.SetParent(wu_Selected.transform, false);
            selectedMarker.transform.localPosition = new Vector3(0, 2.5f, 0);
        }

    }

   
}
