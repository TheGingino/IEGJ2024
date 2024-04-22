using UnityEngine;

public class FollowingPlayer : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FollowPlayer()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
    }

    /*
    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
    }

    */
}