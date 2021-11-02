using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;

public class Unit : MonoBehaviour
{



    [SerializeField] int health = 20;
    NavMeshAgent agent;
    bool isAtPOS = false;
    Vector3 unitPOS;
    public UnitType unitType;
    public enum UnitType
    {
        friendly,
        enemy
    }

   
   [SerializeField] private GameObject[] guardUnits;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isAtPOS = false;
    }

    private void Update()
    {

        switch (unitType)
        {
            case UnitType.friendly:
                GoToUnit();
                break;
            case UnitType.enemy:
                GoToGuard();
                break;
            default:
                break;
        }
    }
    private void GoToUnit ()
    {
        agent.SetDestination(unitPOS);
        agent.isStopped = false;

        if (agent.remainingDistance < 0.3)
        {
            agent.isStopped = true;
            isAtPOS = true;

        }
    }
    public Vector3 GetUnitPosition(Vector3 taskPosition)
    {
        return unitPOS = taskPosition;
    }
    private void GoToGuard()
    {

        guardUnits = GameObject.FindGameObjectsWithTag("Guard");
        int randomNum = Random.Range(0, guardUnits.Length);
        Vector3 pos = guardUnits[randomNum].transform.position;
        agent.SetDestination(pos);
        agent.isStopped = false;

        if (agent.remainingDistance < 0.4)
        {
            agent.isStopped = true;
           

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Guard") && gameObject.tag != "Guard")
        {
            health -= 1;
            print(health);
            if (health < 1)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Enemy") && gameObject.tag != "Enemy")
        {
            health -= 2;
            print(health);
            if (health < 1)
            {
                Destroy(gameObject);
            }
        }
    }


}
