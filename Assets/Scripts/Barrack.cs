using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : MonoBehaviour
{

    [SerializeField] private GameObject buttonObj;
    [SerializeField] private GameObject guard;
    private ResourceInv resourceInv;
     [SerializeField] private GameObject spawnPoint;
   
    void Start()
    {
        resourceInv = GameObject.Find("ResourceHolder").GetComponent<ResourceInv>();
        
        // Using .Find() because I only need this once.
        buttonObj = GameObject.Find("Button_Guard");
        buttonObj.SetActive(false);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButton(0))
            {
                if (hit.collider.tag == "Barrack")
                {
                    buttonObj.SetActive(true);
                }
            }

            if (Input.GetMouseButton(1))
            {
                if (hit.transform.gameObject.layer == 7)
                {
                    buttonObj.SetActive(false);
                }
            }

        }
    }

    public void SpawnGuard()
    {

        if (resourceInv.amountUnit < resourceInv.maxUnit)
        {
            if (resourceInv.food >= 5 && resourceInv.wood >= 3 && resourceInv.stone >= 2)
            {
                resourceInv.amountUnit += 1;
                resourceInv.food -= 5;
                resourceInv.wood -= 3;
                resourceInv.stone -= 2;
                Instantiate(guard, spawnPoint.transform);
            }

        }

    }
}
