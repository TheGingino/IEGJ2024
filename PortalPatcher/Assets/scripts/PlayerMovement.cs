
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic properties")]
    [SerializeField] private float speed = 12;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;
    private Vector3 velocity;

    [Header("Dash properties")]
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDecelerationAir;
    [SerializeField] private float dashDecelerationGround;
    [SerializeField] private float dashIncreaseRate;
    [SerializeField] private float dashCooldown;
    private bool isDashing;
    private Vector3 dashDirection;


    [Header("Ground properties")]
    public Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    [Header("Refrences")]
    public CharacterController controller;
    public Camera cam;

    private void Start()
    {
        //Make sure you start falling fast on startup
        velocity.y = -7f;
    }

    void Update()
    {
        //See if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Stop downwards velocity from increasing while on the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (dashCooldown <= 3)
        {
            StartCoroutine(DashCooldown());
        }


        if (Input.GetKeyDown("left shift"))
        {
            if (!isDashing && dashCooldown >= 1f)
            {

                isDashing = true;
                StartCoroutine(DashCoroutine());

            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //only apply gravity when no dashing
        if (!isDashing)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        //Make you decelerate faster when grounded
        if (isGrounded)
        {
            velocity.x = Mathf.Lerp(velocity.x, 0f, dashDecelerationGround * Time.deltaTime);
            velocity.z = Mathf.Lerp(velocity.z, 0f, dashDecelerationGround * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.Lerp(velocity.x, 0f, dashDecelerationAir * Time.deltaTime);
            velocity.z = Mathf.Lerp(velocity.z, 0f, dashDecelerationAir * Time.deltaTime);
        }

        controller.Move(velocity * Time.deltaTime);

        float moveInputMagnitude = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).sqrMagnitude;

    }

    private IEnumerator DashCooldown()
    {
        if (dashCooldown <= 3 && !isDashing)
            dashCooldown += dashIncreaseRate;

        yield return new WaitForSeconds(0.3f);
    }

    private IEnumerator DashCoroutine()
    {
        dashDirection = (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")).normalized;
        dashCooldown -= 1.1f;


        if (dashDirection == Vector3.zero)
            dashDirection = transform.forward;

        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
            velocity.y = 0;

            yield return null;
        }

        velocity = dashDirection * (dashSpeed - 1.5f);

        isDashing = false;
    }
}
