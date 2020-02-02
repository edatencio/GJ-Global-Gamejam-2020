using UnityEngine;
using NaughtyAttributes;

public class GarraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioSource movingAudioSource;
    [ReadOnly] public GameObject enemyToGrab;
    private bool bajando;

    private void Start()
    {
        bajando = true;
    }

    private void Update()
    {
        if (bajando == true)
        {
            transform.Translate(new Vector3(0f, 5 * -Time.deltaTime * speed, 0f));
            movingAudioSource.gameObject.SetActive(true);
        }
        if (bajando == false)
        {
            transform.Translate(new Vector3(0f, 7 * Time.deltaTime * speed, 0f));
            movingAudioSource.gameObject.SetActive(false);
            Destroy(gameObject, 7f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemyToGrab)
            bajando = false;
    }
}
