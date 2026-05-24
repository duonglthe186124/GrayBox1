using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EntityStats))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float staminaCostPerSecond = 10f;

    private Rigidbody2D rb;
    private EntityStats stats;
    private float moveInput;

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
        if (Mathf.Abs(moveInput) > 0)
        {
            // C? g?ng tr? stamina, n?u th�nh c�ng th� cho ph�p di chuy?n
            if (stats.UseStamina(staminaCostPerSecond * Time.fixedDeltaTime))
            {
                rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
            }
            else
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // H?t s?c th� d?ng
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}
