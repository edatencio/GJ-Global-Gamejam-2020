using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float vel;
    private float ran, i;
    private bool back;
    public EnemyShoot enemyShoot;

    private void Start()
    {
        back = false;
        i = 0;
        ran = Random.Range(3, 6);
    }

    private void Update()
    {
        if (!enemyShoot.reparado)
        {
            i = i + Time.deltaTime;
            if (back == true)
            {
                transform.Translate(new Vector3(vel * Time.deltaTime, 0f, 0f));
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                transform.Translate(new Vector3(-vel * Time.deltaTime, 0f, 0f));
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (i > ran)
            {
                back = !back;
                i = 0;
            }
        }
    }
}
