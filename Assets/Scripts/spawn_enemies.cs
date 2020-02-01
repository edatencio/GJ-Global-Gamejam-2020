using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemies : MonoBehaviour
{
    public GameObject spawnpoint1, spawnpoint2, spawnpoint3;
    public GameObject robot;
    private float timer;
    public float tiempodespawn;
    public int contador;
    [SerializeField]private float randomnumber;

    private void Start()
    {
        timer = 0;
        contador = 0;
        tiempodespawn = 3;

    }
    private void Update()
    {
        if (contador < 15)
        {
            timer = timer + Time.deltaTime;
            if (timer > tiempodespawn)
            {

                timer = 0;
                contador = contador + 1;
                randomnumber = Random.Range(0, 4);
                if (randomnumber <= 1)
                {
                    Instantiate(robot, spawnpoint1.transform.position, transform.rotation);
                }
                if (randomnumber > 1 && randomnumber <= 2)
                {
                    Instantiate(robot, spawnpoint2.transform.position, transform.rotation);
                }
                if (randomnumber > 2 && randomnumber <= 3)
                {
                    Instantiate(robot, spawnpoint3.transform.position, transform.rotation);
                }
            }
        }
        
    }


}
