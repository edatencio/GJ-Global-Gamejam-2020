using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class spawn_enemies : MonoBehaviour
{
    [ReorderableList] public GameObject[] spawnpoint;
    [ReorderableList] public GameObject[] robot;
    [ReorderableList] public GameObject[] musicas;
    [ReadOnly] public float tiempoDeSpawn;
    [ReadOnly] public int contador;
    [ReadOnly] public float randomNumber;
    [SerializeField] private GameObject roof;
    public GameObject[] oleadas;

    [SerializeField] private UnityEvent onGameFinished;
    private float timer;
    private int waves;

    private void Start()
    {
        waves = 0;
        tiempoDeSpawn = 3;
        timer = 0;
        int i;
        for (i = 0; i <= 3; i++)
        {
            musicas[i].SetActive(false);
            oleadas[i].SetActive(false);
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
                oleadas[0].SetActive(true);
                tiempoDeSpawn = 10;
                if (timer > tiempoDeSpawn && contador < 17)
                {
                    timer = 0;
                    contador = contador + 1;
                    randomNumber = Random.Range(0, 4);

                    EnemyShoot enemyShoot = null;

                    if (randomNumber <= 1)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[0].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 1 && randomNumber <= 2)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[1].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 2 && randomNumber <= 3)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[2].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }

                    enemyShoot.roof = roof;
                }
                if (contador >= 17 && timer > 12)
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
                oleadas[1].SetActive(true);
                tiempoDeSpawn = 9;
                if (timer > tiempoDeSpawn && contador < 19)
                {
                    timer = 0;
                    contador = contador + 1;
                    randomNumber = Random.Range(0, 5);

                    EnemyShoot enemyShoot = null;

                    if (randomNumber <= 1)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[0].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 1 && randomNumber <= 2)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[1].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 2 && randomNumber <= 3)
                    {
                        enemyShoot = Instantiate(robot[Random.Range(0, 2)], spawnpoint[2].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 3 && randomNumber <= 4)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[3].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }

                    enemyShoot.roof = roof;
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
                oleadas[2].SetActive(true);
                tiempoDeSpawn = 6;
                if (timer > tiempoDeSpawn && contador < 29)
                {
                    timer = 0;
                    contador = contador + 1;
                    randomNumber = Random.Range(0, 6);

                    EnemyShoot enemyShoot = null;
                    if (randomNumber <= 1)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[0].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 1 && randomNumber <= 2)
                    {
                        enemyShoot = Instantiate(robot[Random.Range(0, 2)], spawnpoint[1].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 2 && randomNumber <= 3)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[2].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 3 && randomNumber <= 4)
                    {
                        enemyShoot = Instantiate(robot[1], spawnpoint[3].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 4 && randomNumber <= 5)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[3].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }

                    enemyShoot.roof = roof;
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
                oleadas[3].SetActive(true);
                tiempoDeSpawn = 5;
                if (timer > tiempoDeSpawn && contador < 35)
                {
                    timer = 0;
                    contador = contador + 1;
                    randomNumber = Random.Range(0, 7);

                    EnemyShoot enemyShoot = null;
                    if (randomNumber <= 1)
                    {
                        enemyShoot = Instantiate(robot[1], spawnpoint[0].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 1 && randomNumber <= 2)
                    {
                        enemyShoot = Instantiate(robot[1], spawnpoint[1].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 2 && randomNumber <= 3)
                    {
                        enemyShoot = Instantiate(robot[0], spawnpoint[2].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 3 && randomNumber <= 4)
                    {
                        enemyShoot = Instantiate(robot[Random.Range(0, 2)], spawnpoint[3].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 4 && randomNumber <= 5)
                    {
                        enemyShoot = Instantiate(robot[1], spawnpoint[3].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    if (randomNumber > 5 && randomNumber <= 6)
                    {
                        enemyShoot = Instantiate(robot[1], spawnpoint[3].transform.position, transform.rotation).GetComponent<EnemyShoot>();
                    }
                    enemyShoot.roof = roof;
                }
                if (contador >= 35 && timer > 12)
                {
                    timer = 0;
                    contador = 0;
                    waves = 4;
                    musicas[3].SetActive(false);
                    onGameFinished.Invoke();
                }
                break;

            case 4:
                break;
        }
    }
}
