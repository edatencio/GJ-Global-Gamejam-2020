using UnityEngine;

public class GarraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool bajando;
    public GameObject enemyToGrab;

    private void Start()
    {
        bajando = true;
    }

    private void Update()
    {
        if (bajando == true)
        {
            transform.Translate(new Vector3(0f, 5 * -Time.deltaTime * speed, 0f));
        }
        if (bajando == false)
        {
            transform.Translate(new Vector3(0f, 7 * Time.deltaTime * speed, 0f));
            Destroy(gameObject, 7);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemyToGrab)
            bajando = false;
    }
}
