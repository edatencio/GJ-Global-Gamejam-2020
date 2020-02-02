using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float vel;
    private float ran, i;
    private bool back;
    public EnemyShoot enemyShoot;
    private float scaleX;

    private void Start()
    {
        back = false;
        i = 0;
        ran = Random.Range(3, 6);
        scaleX = transform.localScale.x;
    }

    private void Update()
    {
        if (!enemyShoot.reparado)
        {
            i = i + Time.deltaTime;
            if (back == true)
            {
                transform.Translate(new Vector3(vel * Time.deltaTime, 0f, 0f));
                transform.localScale = transform.localScale.With(x: scaleX);
            }
            else
            {
                transform.Translate(new Vector3(-vel * Time.deltaTime, 0f, 0f));
                transform.localScale = transform.localScale.With(x: -scaleX);
            }

            if (i > ran && !enemyShoot.PlayerOnSight)
            {
                back = !back;
                i = 0;
            }
        }
    }
}
