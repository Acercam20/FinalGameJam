using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool cameraLock;
    float rotationX = 0;
    [SerializeField]
    private Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    private Vector2 InputVector = Vector2.zero;
    private Vector3 MoveDirection = Vector3.zero;
    Vector3 movementDirection;
    private readonly int MovementXHash = Animator.StringToHash("MovementX");
    private readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private readonly int IsRunningHash = Animator.StringToHash("IsRunning");
    private readonly int IsJumpingHash = Animator.StringToHash("IsJumping");

    private bool IsRunning;
    private bool IsJumping;
    [SerializeField] private float JumpForce;
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;
    private Animator playerAnimator;
    private Rigidbody rb;

    public float gravityScale = 1.0f;
    public static float globalGravity = -8.81f;

    public InputActionAsset asset;
    private InputAction inputAction1;
    private InputAction inputAction2;

    ButtonControl jumpControl;
    ButtonControl hookControl;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        rb.useGravity = false;

        inputAction2 = asset.FindAction("Hook");
        hookControl = (ButtonControl)inputAction2.controls[0];
        inputAction2.Enable();

        inputAction1 = asset.FindAction("Run");
        jumpControl = (ButtonControl)inputAction1.controls[0];
        inputAction1.Enable();
    }

    void Update()
    {

        Running();
        Movement();
    }

    private void Running()
    {
        if (jumpControl.wasPressedThisFrame)
        {
            IsRunning = true;
        }
        if (jumpControl.wasReleasedThisFrame)
        {
            IsRunning = false;
        }
    }

    private void Movement()
    {
        if (!(InputVector.magnitude > 0)) MoveDirection = Vector3.zero;

        MoveDirection = transform.forward * InputVector.y + transform.right * InputVector.x;

        float currentSpeed = IsRunning ? RunSpeed : WalkSpeed;

        movementDirection = Quaternion.Euler(0, 1, 0) * MoveDirection * (currentSpeed * Time.deltaTime);

        transform.position += movementDirection;

        MoveDirection = Vector3.zero;
        movementDirection = Vector3.zero;

        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        InputVector = context.action.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (!cameraLock)
        {
            rotationX += -context.ReadValue<Vector2>().y * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, context.ReadValue<Vector2>().x * lookSpeed, 0);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!IsJumping)
            rb.AddForce((transform.up + MoveDirection) * JumpForce, ForceMode.Impulse);

        IsJumping = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground") && !IsJumping)
        {
            return;
        }

        //GameObject.FindWithTag("SFX").GetComponent<AudioSource>().PlayOneShot(GameObject.FindWithTag("SFX").GetComponent<SFXManager>().landing);

        IsJumping = false;
        //playerAnimator.SetBool(IsJumpingHash, false);
    }

}
