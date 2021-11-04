using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class WorkerUnit : MonoBehaviour
{

    
    NavMeshAgent agent;
    Vector3 resourcePOS;
    ResourceSpawn resourceObj = null;
    public string tagType = null;
    bool isAtPOS = false;
    private ResourceInv inv;

    public float timer = 5;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        inv = GameObject.Find("ResourceHolder").GetComponent<ResourceInv>();
        isAtPOS = false;
    }

    void Update()
    {
        GetResource();

        if (isAtPOS == true)
        {

           StartCoroutine(Production());
        }
    }

    public Vector3 GetTaskPosition(Vector3 taskPosition)
    {
        return resourcePOS = taskPosition;
    }

    public ResourceSpawn GetResourceObject(ResourceSpawn taskObj)
    {
        return resourceObj = taskObj;
    }

    private void GetResource()
    {
        agent.SetDestination(resourcePOS);
        agent.isStopped = false;

        if (agent.remainingDistance < 0.2)
        {
            agent.isStopped = true;
            isAtPOS = true;
            
        }


    }

    IEnumerator Production()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (tagType == "Wood")
            {
                inv.wood += resourceObj.wood;
            }
            if (tagType == "Stone")
            {
                inv.stone += resourceObj.stone;
            }
            if (tagType == "Food")
            {
                inv.food += resourceObj.food;
            }
            timer = 5;
        }       

        yield return new WaitForSeconds(2);
    }
}
 
           
        
        
   
