using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadMainGame : MonoBehaviour
{
    [SerializeField] public float secondsToWait;
    [SerializeField] public string sceneName;
    void Start()
    {
        StartCoroutine(_LoadSceneDelayed());
    }

    public IEnumerator _LoadSceneDelayed()
    {
        Debug.Log("Antes de cargar");

        yield return new WaitForSeconds(secondsToWait);
        Debug.Log("Deberia cargar");
        SceneManager.LoadScene(sceneName);
        yield return null;
    }
}
