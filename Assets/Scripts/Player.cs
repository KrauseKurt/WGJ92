using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    public Vector3 initialVelocity;
    public float minVelocity = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    public bool facingRight = true;
    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        //rb.velocity = initialVelocity;
        rb.AddRelativeForce(Vector3.forward * 200);
        
        
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);

        if(rb.velocity.x < 0)
        {
            spr.flipX = true;
        }else if (rb.velocity.x > 0)
        {
            spr.flipX = false;
        }

    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        print(this.transform.rotation.ToEulerAngles());
        Debug.Log("Out Direction: " + direction);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }
}