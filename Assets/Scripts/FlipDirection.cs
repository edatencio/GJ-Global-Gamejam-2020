using UnityEngine;

public class FlipDirection : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;

    private void Update()
    {
        Vector3 scale = transform.localScale;

        if (rigidbody.velocity.x < -1f)
            scale.x = -1;
        else if (rigidbody.velocity.x > 1f)
            scale.x = 1;

        transform.localScale = scale;
    }
}
