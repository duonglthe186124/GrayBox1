using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EntityStats))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float staminaCostPerSecond = 10f;

    public float minStaminaToMove = 15f;

    private Rigidbody2D rb;
    private EntityStats stats;
    private float moveInput;

    private bool isExhausted = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EntityStats>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(moveInput) == 0 || stats.isExhausted)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return; 
        }

        
        float costThisFrame = staminaCostPerSecond * Time.fixedDeltaTime;

        if (stats.UseStamina(costThisFrame))
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}
