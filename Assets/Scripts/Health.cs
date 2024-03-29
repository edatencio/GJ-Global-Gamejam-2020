using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class Health : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    [SerializeField] private int maxLives;
    [SerializeField] private UnityEvent onHurt;
    [SerializeField] private UnityEvent onCure;
    [SerializeField] private UnityEvent onDeath;

    [ShowNonSerializedField] private int _lives;

    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    private void Start()
    {
        Lives = maxLives;
    }

    /*************************************************************************************************
    *** Properties
    *************************************************************************************************/
    public int Lives
    {
        get { return _lives; }

        private set { _lives = Mathf.Clamp(value, 0, maxLives); }
    }

    /*************************************************************************************************
    *** Methods
    *************************************************************************************************/
    public void Hurt()
    {
        Hurt(1);
    }

    public void Hurt(int amount)
    {
        Lives -= amount;

        onHurt.Invoke();

        if (Lives == 0)
            onDeath.Invoke();
    }

    public void Cure()
    {
        Cure(1);
    }

    public void Cure(int amount)
    {
        Lives += amount;
        onCure.Invoke();
    }
}
