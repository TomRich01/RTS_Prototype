using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;

public class Unit : MonoBehaviour
{


    private ResourceInv inv;
    [SerializeField] int health = 20;
    NavMeshAgent agent;
    public UnitType unitType;
    public enum UnitType
    {
        friendly,
        enemy
    }

   
   [SerializeField] private GameObject[] guardUnits;
    [SerializeField] private GameObject[] enemyUnits;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        inv = GameObject.Find("ResourceHolder").GetComponent<ResourceInv>();
    }

    private void Update()
    {

        switch (unitType)
        {
            case UnitType.friendly:
                GoToEnemy();
                break;
            case UnitType.enemy:
                GoToGuard();
                break;
            default:
                break;
        }
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

    private void GoToEnemy()
    {

        enemyUnits = GameObject.FindGameObjectsWithTag("Enemy");
        int randomNum = Random.Range(0, enemyUnits.Length);
        Vector3 pos = enemyUnits[randomNum].transform.position;
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
                inv.amountUnit--;
                Destroy(gameObject);
            }
        }
    }


}
