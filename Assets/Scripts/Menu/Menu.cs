using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public string sceneName;

    private void Start()
    {
    }

    private void Update()
    {
        if (CustomInput.Jump || CustomInput.Repair)
            ChangeScene();

        if (CustomInput.Down)
            ExitGame();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        //Debug.Log("Sali del juego");
        Application.Quit();
    }
}
