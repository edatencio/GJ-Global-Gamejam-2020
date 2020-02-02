using UnityEngine;
using Surge;
using NaughtyAttributes;

public class Goo : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    [SerializeField] private float duration;
    [SerializeField] private float shrinkDuration;
    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField, ReorderableList] private Collider[] colliders;
    [SerializeField] private AudioClip[] fx_grasa;
    [SerializeField] private AudioSource source;

    private float currentVelocityY;
    private bool once;
    private void Start()
    {
        source.PlayOneShot(fx_grasa[0]);
    }

    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    private void Update()
    {
        if (currentVelocityY != rigidbody.velocity.y)
        {
            currentVelocityY = rigidbody.velocity.y;
            animator.SetFloat("Velocity Y", currentVelocityY);
        }

        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else if (!once && !Activated)
        {
            once = true;
            Activated = true;
            Shrink();
        }
    }

    /*************************************************************************************************
    *** Properties
    *************************************************************************************************/
    public bool Activated { get; set; }

    /*************************************************************************************************
    *** Methods
    *************************************************************************************************/
    public void Shrink()
    {
        for (int i = 0; i < colliders.Length; i++)
            colliders[i].enabled = false;

        rigidbody.isKinematic = true;

        Tween.LocalScale(transform, transform.localScale.With(x: 0f), shrinkDuration, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(fx_grasa[1]);
    }
}
