using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] bool isShell = false;
    [SerializeField] float bullet = 0;
    [SerializeField] float shell = 0;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        AddForce();
    }

    private void AddForce()
    {
        if (isShell)
        {
            rb.AddForce(transform.right * shell);
        Destroy(gameObject, 10);
        }
        else
        {
            rb.AddForce(transform.forward * bullet);
            Destroy(gameObject, 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isShell)
        {
            return;
        }

        if (collision.relativeVelocity.magnitude > 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
