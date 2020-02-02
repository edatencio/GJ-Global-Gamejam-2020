using UnityEngine;

public class ScaleByVelocity : MonoBehaviour
{
    public enum Axis { X, Y }

    public float bias = 1f;
    public float strength = 1f;
    public float maxStrength;
    public Axis axis = Axis.Y;

    public new Rigidbody rigidbody;

    private Vector2 startScale;

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void Update()
    {
        var velocity = rigidbody.velocity.magnitude;
        var amount = Mathf.Clamp(velocity * strength + bias, 0f, maxStrength);
        var inverseAmount = (1f / amount) * startScale.magnitude;

        switch (axis)
        {
            case Axis.X:
                transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(amount, inverseAmount, 1f), Time.deltaTime);
                return;

            case Axis.Y:
                transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(inverseAmount, amount, 1f), Time.deltaTime);
                return;
        }
    }
}
