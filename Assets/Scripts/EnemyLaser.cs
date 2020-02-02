using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed;
    private float timer;
    public GameObject jugador;
    private float scaleX;

    private void Start()
    {
        speed = 1.5f;
        timer = 0;
        jugador = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Vector3 direction = new Vector3(jugador.transform.position.x - transform.position.x, 0f, 0f);
        transform.Translate((direction.normalized) * speed * Time.deltaTime);
        if ((jugador.transform.position.x - transform.position.x) < 0)
        {
            transform.localScale = transform.localScale.With(x: -scaleX);
        }
        timer = timer + Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
