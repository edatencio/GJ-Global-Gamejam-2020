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

    private float currentVelocityY;
    private bool once;

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
}
