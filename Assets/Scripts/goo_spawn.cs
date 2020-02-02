using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goo_spawn : MonoBehaviour
{
    public GameObject[] puntos;
    public GameObject grasa;
    private float i;

    private void Start()
    {
        i = 0;
    }

    private void Update()
    {
        i = i + Time.deltaTime;
        if (i > 17)
        {
            i = 0;
            Instantiate(grasa, puntos[Random.Range(0, puntos.Length)].transform.position, transform.rotation);
        }
    }
}
