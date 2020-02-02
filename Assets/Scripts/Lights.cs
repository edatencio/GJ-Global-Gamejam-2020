using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using Surge;

public class Lights : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    [SerializeField, MinMaxSlider(0, 10)] private Vector2 randomRange;
    [SerializeField] private float duration;
    [SerializeField] private Light playerLight;
    [SerializeField] private Light directionalLight;
    [SerializeField, ReorderableList] private Light[] environmentLights;
    [SerializeField] private UnityEvent onTurnOn;
    [SerializeField] private UnityEvent onTurnOff;

    private float playerLightIntensity;
    private float directionalLightIntensity;
    private float environmentLightsIntensity;
    private float timer;
    private bool on;

    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    private void Start()
    {
        playerLightIntensity = playerLight.intensity;
        directionalLightIntensity = directionalLight.intensity;
        environmentLightsIntensity = environmentLights[0].intensity;
        On();
        timer = randomRange.y;
    }

    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    private void Update()
    {
        if (timer == 0)
        {
            timer = Random.Range(randomRange.x, randomRange.y);

            if (!on)
                On();
            else
                Off();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    /*************************************************************************************************
    *** Properties
    *************************************************************************************************/

    /*************************************************************************************************
    *** Methods
    *************************************************************************************************/
    [Button]
    public void On()
    {
        if (Application.isPlaying)
        {
            Tween.Value(playerLightIntensity, 0f, (value) => playerLight.intensity = value, duration, 0f);
            Tween.Value(0f, directionalLightIntensity, (value) => directionalLight.intensity = value, duration, 0f);
            Tween.Value(0f, environmentLightsIntensity, SetEnvironmentLightsIntensity, duration, 0f);
            onTurnOn.Invoke();
            on = true;
        }
    }

    [Button]
    public void Off()
    {
        if (Application.isPlaying)
        {
            Tween.Value(0f, playerLightIntensity, (value) => playerLight.intensity = value, duration, 0f);
            Tween.Value(directionalLightIntensity, 0f, (value) => directionalLight.intensity = value, duration, 0f);
            Tween.Value(environmentLightsIntensity, 0f, SetEnvironmentLightsIntensity, duration, 0f);
            onTurnOff.Invoke();
            on = false;
        }
    }

    private void SetEnvironmentLightsIntensity(float value)
    {
        for (int i = 0; i < environmentLights.Length; i++)
            environmentLights[i].intensity = value;
    }
}
