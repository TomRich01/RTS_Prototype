using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
    [SerializeField] private GameObject textObj;
    [SerializeField] private GameObject worker;
    [SerializeField] private ResourceInv resourceInv;
    [SerializeField] private GameObject spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        textObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButton(0))
            {
                if (hit.collider.tag == "Base")
                {
                    textObj.SetActive(true);
                }
            }

            if (Input.GetMouseButton(1))
            {
                if (hit.transform.gameObject.layer == 7)
                {
                    textObj.SetActive(false);
                }
            }
           
        }
    }

    public void SpawnWorker()
    {
        if (resourceInv.amountUnit < resourceInv.maxUnit)
        {
            resourceInv.amountUnit += 1;
            resourceInv.food -= 5;
            Instantiate(worker, spawnPoint.transform);
        }
        
    }
}
