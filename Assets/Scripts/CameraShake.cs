using UnityEngine;
using NaughtyAttributes;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration = 0.25f;
    [SerializeField] private float amount = 0.7f;
    [SerializeField] private float decreaseFactor = 1.0f;
    [SerializeField] private bool shakeOnEnable;

    private Vector3 startPosition;
    private float shakeDuration;

    private void OnEnable()
    {
        startPosition = transform.localPosition;

        if (shakeOnEnable)
            Run();
    }

    private void Update()
    {
        if (IsRunning)
        {
            if (shakeDuration > 0)
            {
                transform.localPosition = startPosition + Random.insideUnitSphere * amount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                IsRunning = false;
                transform.localPosition = startPosition;
            }
        }
    }

    public bool IsRunning { get; private set; }

    [Button]
    public void Run()
    {
        IsRunning = true;
        shakeDuration = duration;
    }

    public void Run(float duration)
    {
        IsRunning = true;
        shakeDuration = duration;
    }

    [Button]
    public void Stop()
    {
        IsRunning = false;
    }
}
