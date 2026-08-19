using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 24f;
    public float runSpeed = 48f;
    public float jumpForce = 6f;
    private bool _isRunning = false;
    private bool _isGrounded = false;
    public float gravity = -20f;
    private Rigidbody _rb;

    [Header("Mouse Look")]
    public float mouseSensitivity = 2f;
    public Transform cameraHolder;

    float xRotation;
    float yVelocity;
    CharacterController controller;

    [Header("WwiseEvents")]
    public AK.Wwise.Switch footstepSwitch;
    public AK.Wwise.RTPC rtpcPlayerSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        footstepSwitch.SetValue(gameObject);
    }

    void Update()
    {
        if (GameManager.Instance != null && !GameManager.Instance.IsGameActive) return;

        HandleMouseLook();
        HandleMovement();
       // HandleJump();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);

        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rtpcPlayerSpeed.SetGlobalValue(1);
            _isRunning = true;
        }
        else
        {
            rtpcPlayerSpeed.SetGlobalValue(0);
            _isRunning = false;
        }
        float speed = _isRunning ? runSpeed : moveSpeed;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (controller.isGrounded && yVelocity < 0f)
            yVelocity = -2f;

        yVelocity += gravity * Time.deltaTime;
        move.y = yVelocity;

        controller.Move(move * speed * Time.deltaTime);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
