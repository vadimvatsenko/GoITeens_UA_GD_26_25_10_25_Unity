using UnityEngine;

public class FpsMovement : MonoBehaviour
{
    [Header("Movement")] [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Ground Check")] 
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private Transform groundCheck;

    [Header("Mouse Look")]
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float mouseLookSensitivity = 200f;
    [SerializeField] private float maxLoockAngle = 80f;
    
    [Header("Fire Info")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private float _xRotation;
    private bool _isGrounded;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        IsGrounded();
        Jump();
        Look();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 shootDirection = cameraTransform.forward;

            GameObject bullet 
                = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootDirection));
            Bullet bull = bullet.GetComponent<Bullet>();
            
            bull.SpawnBullet(shootDirection);
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Рух вправо/ліво відносно повороту гравця
        Vector3 movementDirection = transform.right * horizontal;
        
        // Рух вперед/назад відносно поворота гравця
        movementDirection += transform.forward * vertical;
        
        movementDirection = movementDirection.normalized;
        
        Vector3 velocity = movementDirection * moveSpeed;
        
        velocity.y = _rb.linearVelocity.y;
     
        // Застосовуємо швидкість
        _rb.linearVelocity = velocity;
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseLookSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseLookSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -maxLoockAngle, maxLoockAngle); 

        cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        
        transform.Rotate(Vector3.up * mouseX);
    }

    private void IsGrounded()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = _isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    
}

