using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed;
    private float timer;
    public GameObject jugador;
    private float scaleX;

    private Vector3 direction;

    private void Start()
    {
        speed = 1.5f;
        timer = 0;
        jugador = GameObject.FindWithTag("Player");
        scaleX = transform.localScale.x;
        direction = new Vector3(jugador.transform.position.x - transform.position.x, 0f, 0f);
    }

    private void Update()
    {
        transform.Translate(direction.normalized * speed);

        if ((jugador.transform.position.x - transform.position.x) < 0)
            transform.localScale = transform.localScale.With(x: -scaleX);

        timer += Time.deltaTime;

        if (timer >= 5f)
            Destroy(gameObject);
    }
}
