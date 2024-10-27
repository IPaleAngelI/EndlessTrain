using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float acceleration;
    Animator animator;
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";
    private float speed;
    private float velocity;
    public KeyCode walkKey = KeyCode.LeftShift;

    private void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        int velocityHash = Animator.StringToHash("velocity");
        if (!Input.anyKey)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }
        animator.SetFloat(velocityHash, velocity);
        if (Input.GetMouseButton(0))
        {
            Aim();
        }
        Debug.Log(velocity);
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (direction != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
        CycleMovement();

    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }
    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;

            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }
    public movementMode mode;
    public enum movementMode
    {
        walking,
        sprinting
    }

    private void CycleMovement()
    {
        //walking
        if (!(Input.GetMouseButton(0) || Input.GetKey(walkKey)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))) // если нет нажатие на шифт или ЛКМ И ПРИ ЭТОМ есть нажатие на W, A, S или D
        {
            mode = movementMode.sprinting;
            speed = sprintSpeed;
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", true);
        }
        else if ((Input.GetMouseButton(0) || Input.GetKey(walkKey)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            mode = movementMode.walking;
            speed = walkSpeed;
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", false);
        }
    }
}
