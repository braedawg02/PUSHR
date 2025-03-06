using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float speed = 5.0f;
    public float maxZ = 10.0f;
    public float offset = 0.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float z = Mathf.Sin(Time.time * speed) * maxZ + offset;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, z);
        rb.MovePosition(newPosition);
    }
}