using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemies : MonoBehaviour
{
    public GameObject[] spawnpoint;
    public GameObject[] robot;
    public GameObject[] musicas;
    private float timer;
    public float tiempodespawn;
    public int contador;
    [SerializeField]private float randomnumber;
    private int waves;

    private void Start()
    {
        waves = 0;
        tiempodespawn = 3;
        timer = 0;
        int i;
        for (i = 0; i < 3; i++)
        {
            musicas[i].SetActive(false);
        }
        contador = 0;

    }
    private void Update()
    {
        timer = timer + Time.deltaTime;
        switch (waves)
        {            
            /*      ****    WAVE 1  ****    */
            case 0:
                musicas[0].SetActive(true);
                tiempodespawn = 10;  
                if (timer > tiempodespawn && contador<17)
                {
                    timer = 0;
                    contador = contador + 1;
                    randomnumber = Random.Range(0, 4);
                    if (randomnumber <= 1)
                    {
                        Instantiate(robot[0], spawnpoint[0].transform.position, transform.rotation);
                    }
                    if (randomnumber > 1 && randomnumber <= 2)
                    {
                        Instantiate(robot[0], spawnpoint[1].transform.position, transform.rotation);
                    }
                    if (randomnumber > 2 && randomnumber <= 3)
                    {
                        Instantiate(robot[0], spawnpoint[2].transform.position, transform.rotation);
                    }
                }
                if (contador >= 17 && timer>12)
                {
                    timer = 0;
                    contador = 0;
                    waves = 1;
                    musicas[0].SetActive(false);
                }
                break;

            /*  ****    WAVE 2  ****    */
            case 1:
                musicas[1].SetActive(true);
                tiempodespawn = 9;
                if (timer > tiempodespawn && contador < 19)
                {
                    timer = 0;
                    contador = contador + 1;
                    randomnumber = Random.Range(0, 5);
                    if (randomnumber <= 1)
                    {
                        Instantiate(robot[0], spawnpoint[0].transform.position, transform.rotation);
                    }
                    if (randomnumber > 1 && randomnumber <= 2)
                    {
                        Instantiate(robot[0], spawnpoint[1].transform.position, transform.rotation);
                    }
                    if (randomnumber > 2 && randomnumber <= 3)
                    {
                        Instantiate(robot[Random.Range(0,2)], spawnpoint[2].transform.position, transform.rotation);
                    }
                    if (randomnumber > 3 && randomnumber <= 4)
                    {
                        Instantiate(robot[0], spawnpoint[3].transform.position, transform.rotation);
                    }
                }
                if (contador >= 19 && timer > 12)
                {
                    timer = 0;
                    contador = 0;
                    waves = 2;
                    musicas[1].SetActive(false);
                }
                break;

            /*  ****    WAVE 3  ****    */
            case 2:
                musicas[2].SetActive(true);
                tiempodespawn = 6;
                if (timer > tiempodespawn && contador < 29)
                {
                    timer = 0;
                    contador = contador + 1;
                    randomnumber = Random.Range(0, 6);
                    if (randomnumber <= 1)
                    {
                        Instantiate(robot[0], spawnpoint[0].transform.position, transform.rotation);
                    }
                    if (randomnumber > 1 && randomnumber <= 2)
                    {
                        Instantiate(robot[Random.Range(0, 2)], spawnpoint[1].transform.position, transform.rotation);
                    }
                    if (randomnumber > 2 && randomnumber <= 3)
                    {
                        Instantiate(robot[0], spawnpoint[2].transform.position, transform.rotation);
                    }
                    if (randomnumber > 3 && randomnumber <= 4)
                    {
                        Instantiate(robot[1], spawnpoint[3].transform.position, transform.rotation);
                    }
                    if (randomnumber > 4 && randomnumber <= 5)
                    {
                        Instantiate(robot[0], spawnpoint[3].transform.position, transform.rotation);
                    }
                }
                if (contador >= 29 && timer > 12)
                {
                    timer = 0;
                    contador = 0;
                    waves = 3;
                    musicas[2].SetActive(false);
                }
                break;

            /*  ****    WAVE 4  ****    */
            case 3:
                musicas[3].SetActive(true);
                tiempodespawn = 5;
                if (timer > tiempodespawn && contador < 35)
                {
                    timer = 0;
                    contador = contador + 1;
                    randomnumber = Random.Range(0, 7);
                    if (randomnumber <= 1)
                    {
                        Instantiate(robot[1], spawnpoint[0].transform.position, transform.rotation);
                    }
                    if (randomnumber > 1 && randomnumber <= 2)
                    {
                        Instantiate(robot[1], spawnpoint[1].transform.position, transform.rotation);
                    }
                    if (randomnumber > 2 && randomnumber <= 3)
                    {
                        Instantiate(robot[0], spawnpoint[2].transform.position, transform.rotation);
                    }
                    if (randomnumber > 3 && randomnumber <= 4)
                    {
                        Instantiate(robot[Random.Range(0,2)], spawnpoint[3].transform.position, transform.rotation);
                    }
                    if (randomnumber > 4 && randomnumber <= 5)
                    {
                        Instantiate(robot[1], spawnpoint[3].transform.position, transform.rotation);
                    }
                    if (randomnumber > 5 && randomnumber <= 6)
                    {
                        Instantiate(robot[1], spawnpoint[3].transform.position, transform.rotation);
                    }
                }
                if (contador >= 35 && timer > 12)
                {
                    timer = 0;
                    contador = 0;
                    waves = 4;
                    musicas[3].SetActive(false);
                }
                break;

            case 4:
                /*      GANAR   */
                break;
        }
                
    }
}
