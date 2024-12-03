using Unity.VisualScripting;
using UnityEngine;
using Fusion;
using Fusion.Photon.Realtime; // Импортируем Fusion для сетевой функциональности

public class PlayerController : NetworkBehaviour // Наследуем от NetworkBehaviour для сетевой функциональности
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float rotationSpeed = 720f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Camera mainCamera;

    private Animator animator;
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";
    private float speed;
    private float velocity;

    private void Start()
    {
        if (GetComponent<Camera>() != null)
        {
            
            mainCamera = Camera.main;
        }
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Проверяем, есть ли у нас права на ввод и принадлежит ли объект текущему игроку
        if (Object.InputAuthority == null || !IsLocalPlayer())
            return;

        HandleMovement();
        UpdateAnimator();
    }

    private bool IsLocalPlayer()
    {
        // Проверяем, является ли текущий объект локальным игроком
        return Object.InputAuthority == Runner.LocalPlayer;
    }

    private void HandleMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));
        direction.Normalize();

        if (direction != Vector3.zero)
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            Quaternion desiredRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void UpdateAnimator()
    {
        int velocityHash = Animator.StringToHash("velocity");
        animator.SetFloat(velocityHash, velocity);
        
        if (Input.anyKey)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", Input.GetKey(KeyCode.LeftShift));
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }
    }

    public override void Spawned()
    {
        // Логика при спавне игрока
        if (Object.InputAuthority != null)
        {
            // Здесь можно добавить логику для инициализации игрока
        }
    }
}