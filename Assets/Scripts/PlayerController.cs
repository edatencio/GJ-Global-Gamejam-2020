using UnityEngine;
using NaughtyAttributes;
using Surge;

public class PlayerController : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    [SerializeField, BoxGroup("Settings")] private float jumpForce;
    [SerializeField, BoxGroup("Settings")] private float movementSpeed;
    [SerializeField, BoxGroup("Settings")] private float gravityForce;
    [SerializeField, BoxGroup("References")] private new Rigidbody rigidbody;
    [SerializeField, BoxGroup("References")] private Transform groundCheck;
    [SerializeField, BoxGroup("References")] private LayerMask groundLayer;

    private bool previousIsGrounded;

    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    private void Start()
    {
    }

    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    private void Update()
    {
        ProcessInput();

        FlipSprite();
    }

    /*************************************************************************************************
    *** FixedUpdate
    *************************************************************************************************/
    private void FixedUpdate()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
    }

    /*************************************************************************************************
    *** Properties
    *************************************************************************************************/
    public bool IsGrounded
    {
        get;
        private set;
    }

    /*************************************************************************************************
    *** Methods
    *************************************************************************************************/
    private void ProcessInput()
    {
        Vector2 velocity = Vector2.zero;

        velocity.y = rigidbody.velocity.y;

        if (IsGrounded)
        {
            if (CustomInput.Jump)
                velocity.y = jumpForce;
        }
        else
        {
            velocity.y -= gravityForce;
        }

        if (CustomInput.Right)
            velocity.x = movementSpeed;

        if (CustomInput.Left)
            velocity.x = -movementSpeed;

        rigidbody.velocity = velocity;
    }

    private void FlipSprite()
    {
        Vector3 scale = transform.localScale;

        if (rigidbody.velocity.x < -1f)
            scale.x = -1;
        else if (rigidbody.velocity.x > 1f)
            scale.x = 1;

        transform.localScale = scale;
    }
}
