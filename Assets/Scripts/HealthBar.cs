using UnityEngine;
using NaughtyAttributes;

public class HealthBar : MonoBehaviour
{
    [SerializeField, ReorderableList] private GameObject[] healthIcons;

    private int _lives;
    private int Lives
    {
        get { return _lives; }
        set { _lives = Mathf.Clamp(value, 0, healthIcons.Length); }
    }

    private void Start()
    {
        Lives = healthIcons.Length;
    }

    [Button]
    public void Increase()
    {
        Lives++;
        SetLives();
    }

    [Button]
    public void Decrease()
    {
        Lives--;
        SetLives();
    }

    private void SetLives()
    {
        for (int i = 0; i < healthIcons.Length; i++)
            healthIcons[i].SetActive(false);

        if (Lives > 0)
        {
            for (int i = 0; i < Lives; i++)
                healthIcons[i].SetActive(true);
        }
    }
}
