using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    public Vector3 initialVelocity;
    public float minVelocity = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;
    
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        Debug.Log("Out Direction: " + direction);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }
}