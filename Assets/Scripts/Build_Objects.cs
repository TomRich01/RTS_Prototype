using UnityEngine;

public class Build_Objects : MonoBehaviour
{
    public GameObject barracks_obj;
    public GameObject house_obj;
    public GameObject button_barracks;

    [SerializeField] private ResourceInv resourceInv;

    public void SpawnBarracks()
    {
        if (resourceInv.wood >= 10 && resourceInv.stone >= 20)
        {
            Instantiate(barracks_obj);
            resourceInv.wood -= 10;
            resourceInv.stone -= 20;
            Destroy(button_barracks);
        }
    }

    public void SpawnHouse()
    {
        if (resourceInv.wood >= 6 && resourceInv.stone >= 4)
        {
            Instantiate(house_obj);
            resourceInv.wood -= 6;
            resourceInv.stone -= 4;
            resourceInv.maxUnit += 3;
        }

    }

}
