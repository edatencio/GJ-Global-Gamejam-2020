using UnityEngine;

public class PlayerRepair : MonoBehaviour
{
    private Health otherHealth;

    private void Update()
    {
        if (otherHealth != null && CustomInput.Repair)
            otherHealth.Hurt();
    }

    private void OnTriggerEnter(Collider other)
    {
        otherHealth = other.GetComponent<Health>();
    }

    private void OnTriggerExit(Collider other)
    {
        otherHealth = null;
    }
}
