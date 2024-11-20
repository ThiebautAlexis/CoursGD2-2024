using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;
    [SerializeField] private float speedCoefficient = 2.0f;
    private bool isSprinting = false;
    [SerializeField, Range(1.0f, 10.0f)] private float speed = 1.0f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private bool canJump = false;
    bool isDashing = false;
    Vector2 dashDirection;
    [SerializeField] private float dashDuration = .25f;
    private float dashTimer = 0f;
    [SerializeField] private float dashSpeed = 25f;

    [SerializeField] private AccelerationSettings accelerationSettings;
    [SerializeField] private float accelerationTimer = 0f;

    public float SpeedCoefficient
    {
        get { return speedCoefficient; }
        set
        {
            if (value <= 0f)
                speedCoefficient = 1f;
        }
    }

    public void MoveCharacter(InputAction.CallbackContext context)
    {
        Debug.Log("Input Pressed");
        direction = context.ReadValue<Vector2>();
        if (context.started)
            accelerationTimer = 0f; 
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
        {
            rigidBody.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed && !isDashing)
        {
            dashTimer = 0f; 
            dashDirection = direction;
            isDashing = true; 
        }
        /*
    if (context.performed)
        isSprinting = true;
    else if (context.canceled)
        isSprinting = false; 
    */
    }



    private void Update()
    {
        if(isDashing)
        {
            transform.position += (Vector3)dashDirection * Time.deltaTime * dashSpeed;
            dashTimer += Time.deltaTime;
            if (dashTimer > dashDuration)
                isDashing = false; 
            return; 
        }
        //float currentSpeed = speed;
        //if (isSprinting) currentSpeed *= speedCoefficient;

        accelerationTimer += Time.deltaTime;
        speed = accelerationSettings.ComputeSpeed(accelerationTimer); 
        transform.position += (Vector3)direction * Time.deltaTime * speed;
    }

    public void TestMethod()
    {
        Debug.Log("test");
    }

    private void MoveRight()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            canJump = false;
    }
}
