using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class LegoCharacterController : MonoBehaviour
{
    [Header("“∆∂Ø…Ë÷√")]
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 240f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;
    private float currentSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Debug.Log("Animator found: " + (animator != null));
    }

    void Update()
    {
        HandleMovement();
        HandleGravity();
        UpdateAnimator();
    }

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");  // A/D
        float v = Input.GetAxis("Vertical");    // W/S

        Vector3 move = new Vector3(h, 0, v);

        if (move.magnitude > 1f)
            move.Normalize();

        Vector3 moveDir = move * moveSpeed * Time.deltaTime;
        controller.Move(moveDir);

        currentSpeed = move.magnitude * moveSpeed;

        if (move.magnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
        }
    }

    void HandleGravity()
    {
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -1f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    void UpdateAnimator()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", currentSpeed);
        }
    }
}
