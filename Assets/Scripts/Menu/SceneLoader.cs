using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private bool changeWithInput;
    [SerializeField] private bool changeWithAnyInput;

    private void Update()
    {
        if (changeWithInput)
        {
            if (CustomInput.Jump || CustomInput.Repair)
                ChangeScene();

            if (CustomInput.Down)
                ExitGame();
        }

        if (changeWithAnyInput && CustomInput.AnyButton)
            ChangeScene();
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
