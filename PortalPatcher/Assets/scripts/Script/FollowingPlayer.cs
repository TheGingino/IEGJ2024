using UnityEngine;

public class FollowingPlayer : MonoBehaviour
{
    [SerializeField] public GameObject target;
    public float speed = 4f;
    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target.transform);
    }
    /*public void FollowPlayer()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
    }
   */
}