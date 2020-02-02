using UnityEngine;

public class PlayerRepair : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Health otherHealth;

    private void Update()
    {
        if (otherHealth != null && otherHealth.Lives > 0 && CustomInput.Repair)
        {
            animator.SetTrigger("Repair");
            otherHealth.Hurt();
        }
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
