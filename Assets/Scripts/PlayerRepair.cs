using UnityEngine;

public class PlayerRepair : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    private Health otherHealth;

    private void Update()
    {
        if (otherHealth != null && otherHealth.Lives > 0 && CustomInput.Repair)
        {
            animator.SetTrigger("Repair");
            otherHealth.Hurt();
            audioSource.PlayOneShot(audioSource.clip);
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
