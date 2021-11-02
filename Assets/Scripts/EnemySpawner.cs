using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyObj;
    [SerializeField] float timer = 100;
    [SerializeField] float resetTimer = 1000;
    [SerializeField] float timeDelay = 1000;
    [SerializeField] float timeRepeat = 1000;


    public int waves = 0;
   

    private void Update()
    {
        InvokeRepeating("Spawn", timeDelay, timeRepeat);
    }

    void Spawn()
    {
        if (waves < 3)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
               
                waves++;
                Instantiate(enemyObj, transform.position, transform.rotation);
                Instantiate(enemyObj, transform.position, transform.rotation);
                timer = resetTimer;
            }
        }
        

    }
}
