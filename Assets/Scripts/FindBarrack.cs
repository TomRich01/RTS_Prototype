using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBarrack : MonoBehaviour
{
    private Barrack barrack;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        barrack = GameObject.FindGameObjectWithTag("Barrack").GetComponent<Barrack>();
        barrack.SpawnGuard();
    }
}
