using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed;
    private float timer;
    public GameObject jugador;

    private void Start()
    {
        speed = 1.5f;
        timer = 0;
        jugador = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Vector3 direction = new Vector3(jugador.transform.position.x - transform.position.x, 0f, 0f);
        transform.Translate(direction * speed * Time.deltaTime);

        timer = timer + Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
        }
    }
}
