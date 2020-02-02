using UnityEngine;
using NaughtyAttributes;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    [SerializeField, BoxGroup("Settings")] private float jumpForce;
    [SerializeField, BoxGroup("Settings")] private float movementSpeed;
    [SerializeField, BoxGroup("Settings")] private float gravityForce;
    [SerializeField, BoxGroup("Settings")] private float gooStunTime;
    [SerializeField, BoxGroup("Settings")] private LayerMask groundLayer;
    [SerializeField, BoxGroup("Settings")] private LayerMask fallThroughPlatformsLayer;
    [SerializeField, BoxGroup("References")] private new Rigidbody rigidbody;
    [SerializeField, BoxGroup("References")] private new Collider collider;
    [SerializeField, BoxGroup("References")] private Transform groundCheck;
    [SerializeField, BoxGroup("References")] private ParticleSystem runParticleSystem;
    [SerializeField, BoxGroup("References")] private ParticleSystem deathParticleSystem;
    [SerializeField, BoxGroup("References")] private Health health;
    [SerializeField, BoxGroup("References")] private Animator animator;

    private LayerMask startLayer;
    private Collider currentGround;
    private float targetHeight;
    private bool stunned;

    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    private void Start()
    {
        startLayer = gameObject.layer;
    }

    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    private void Update()
    {
        if (!stunned)
        {
            ProcessInput();
            FallThroughPlatforms();
            ParticleSystems();
        }

        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, 0.25f, groundLayer);
    }

    /*************************************************************************************************
    *** OnCollision
    *************************************************************************************************/
    private void OnCollisionEnter(Collision collision)
    {
        // Ground
        if (collision.gameObject.layer == groundLayer.layer())
            currentGround = collision.collider;

        // Enemy laser
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            health.Hurt();
        }

        // Enemy goo
        if (collision.gameObject.CompareTag("Goo"))
        {
            Goo goo = collision.gameObject.GetComponent<Goo>();

            if (!goo.Activated)
            {
                goo.Activated = true;
                StartCoroutine(Stun(goo));
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider == currentGround)
            currentGround = null;
    }

    /*************************************************************************************************
    *** Properties
    *************************************************************************************************/
    public bool IsGrounded { get; private set; }

    [ShowNativeProperty]
    public Vector3 vel { get { return rigidbody.velocity; } }

    /*************************************************************************************************
    *** Methods
    *************************************************************************************************/
    private void ProcessInput()
    {
        Vector2 velocity = Vector2.zero;

        velocity.y = rigidbody.velocity.y;

        if (IsGrounded)
        {
            if (!CustomInput.Down && CustomInput.Jump)
            {
                velocity.y = jumpForce;
                animator.SetTrigger("Jump");
            }
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

    private void FallThroughPlatforms()
    {
        bool jumping = rigidbody.velocity.y > 1f;
        bool button = IsGrounded && CustomInput.Down && CustomInput.Jump;

        if (jumping)
            gameObject.layer = fallThroughPlatformsLayer.layer();
        else if (targetHeight == 0f)
            gameObject.layer = startLayer;

        if (button)
        {
            float playerPosition = transform.position.y;
            float playerHeight = collider.bounds.size.y;
            float groundBoundSize = currentGround.bounds.size.y;

            targetHeight = playerPosition - (playerHeight + groundBoundSize);

            gameObject.layer = fallThroughPlatformsLayer.layer();
        }
        else if (targetHeight != 0f && transform.position.y <= targetHeight)
        {
            targetHeight = 0f;
            gameObject.layer = startLayer;
        }
    }

    private void ParticleSystems()
    {
        if (Mathf.Abs(rigidbody.velocity.x) > 0f && IsGrounded)
        {
            if (!runParticleSystem.isPlaying)
                runParticleSystem.Play();
        }
        else if (runParticleSystem.isPlaying)
        {
            runParticleSystem.Stop();
        }
    }

    private IEnumerator Stun(Goo goo)
    {
        rigidbody.isKinematic = true;
        stunned = true;
        animator.SetBool("TrappedInGoo", true);
        runParticleSystem.Stop();
        yield return new WaitForSeconds(gooStunTime);
        rigidbody.isKinematic = false;
        animator.SetBool("TrappedInGoo", false);
        stunned = false;
        goo.Shrink();
    }

    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetTrigger("Jump");
        rigidbody.velocity = rigidbody.velocity.With(y: jumpForce);
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Velocity X", Mathf.Abs(rigidbody.velocity.x));
        animator.SetFloat("Velocity Y", rigidbody.velocity.y);

        bool crouch = IsGrounded && CustomInput.Down;
        animator.SetBool("Crouch", crouch);

        if (crouch)
            rigidbody.velocity = rigidbody.velocity.With(x: 0f);
    }

    public void InstantiateDeathParticles()
    {
        Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
    }

    [Button]
    private void Hurt()
    {
        GetComponent<Health>().Hurt();
    }

    [Button]
    private void Cure()
    {
        GetComponent<Health>().Cure();
    }
}
